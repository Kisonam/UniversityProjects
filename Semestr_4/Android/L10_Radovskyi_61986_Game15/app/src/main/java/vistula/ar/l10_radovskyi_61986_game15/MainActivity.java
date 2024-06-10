package vistula.ar.l10_radovskyi_61986_game15;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.constraintlayout.widget.ConstraintSet;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    int Steps = 0;
    int[] numbers;
    int[] NumbersAfterPermutation;
    int[] PlayerNumbers;
    Button[][] buttons;
    int[][] buttonsID;
    int left, top, result;
    int totalButtons;
    TextView txtScore, txtSteps;
    int buttonWidth = 250, buttonHeight = 200;
    ConstraintLayout constraintLayout;
    ConstraintLayout.LayoutParams params;
    ConstraintSet set;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        txtScore = (TextView) findViewById(R.id.txtScore);
        txtSteps = (TextView) findViewById(R.id.txtSteps);
    }
    final View.OnClickListener buttonClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Button clickedButton = (Button)view;
            int clickedNumber = Integer.parseInt(clickedButton.getText().toString());

            int clickedRow = -1;
            int clickedColumn = -1;
            outerLoop:
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    if (buttons[i][j].getId() == clickedButton.getId()) {
                        clickedRow = i;
                        clickedColumn = j;
                        break outerLoop;
                    }
                }
            }
            boolean canMove = false;

            if (clickedColumn > 0 && NumbersAfterPermutation[clickedRow * 4 + (clickedColumn - 1)] == 0) {
                canMove = true;
            }

            else if (clickedRow > 0 && NumbersAfterPermutation[(clickedRow - 1) * 4 + clickedColumn] == 0) {
                canMove = true;
            }

            else if (clickedColumn < 3 && NumbersAfterPermutation[clickedRow * 4 + (clickedColumn + 1)] == 0) {
                canMove = true;
            }

            else if (clickedRow < 3 && NumbersAfterPermutation[(clickedRow + 1) * 4 + clickedColumn] == 0) {
                canMove = true;
            }

            if (canMove) {

                if (clickedColumn > 0 && NumbersAfterPermutation[clickedRow * 4 + (clickedColumn - 1)] == 0) {
                    NumbersAfterPermutation[clickedRow * 4 + (clickedColumn - 1)] = clickedNumber;
                    NumbersAfterPermutation[clickedRow * 4 + clickedColumn] = 0;
                }
                // Up movement
                else if (clickedRow > 0 && NumbersAfterPermutation[(clickedRow - 1) * 4 + clickedColumn] == 0) {
                    NumbersAfterPermutation[(clickedRow - 1) * 4 + clickedColumn] = clickedNumber;
                    NumbersAfterPermutation[clickedRow * 4 + clickedColumn] = 0;
                }

                else if (clickedColumn < 3 && NumbersAfterPermutation[clickedRow * 4 + (clickedColumn + 1)] == 0) {
                    NumbersAfterPermutation[clickedRow * 4 + (clickedColumn + 1)] = clickedNumber;
                    NumbersAfterPermutation[clickedRow * 4 + clickedColumn] = 0;
                }

                else if (clickedRow < 3 && NumbersAfterPermutation[(clickedRow + 1) * 4 + clickedColumn] == 0) {
                    NumbersAfterPermutation[(clickedRow + 1) * 4 + clickedColumn] = clickedNumber;
                    NumbersAfterPermutation[clickedRow * 4 + clickedColumn] = 0;
                }


                if (NumbersAfterPermutation[clickedRow * 4 + clickedColumn] == clickedRow * 4 + clickedColumn + 1) {
                    result++;
                }
                numbersButtons();


                if (clickedNumber == clickedRow * 4 + clickedColumn + 1) {
                    result++;
                }

                if (checkWinCondition()) {
                    Toast.makeText(MainActivity.this, "Victory!", Toast.LENGTH_SHORT).show();
                }
                Steps++;
                txtScore.setText(Integer.toString(result));
                txtSteps.setText(Integer.toString(Steps));
            }
        }

    };

    public void btnNewGame(View view){
    txtSteps.setText(Integer.toString(0));
    txtScore.setText(Integer.toString(0));
        InitializeButtons();
        NumbersAfterPermutation = AlgorytmPermuntacji.shuffleFisherYeats(numbers);
        numbersButtons();
    }

    private void InitializeButtons() {

        totalButtons = 4 * 4;
        constraintLayout = (ConstraintLayout) findViewById(R.id.constraintLayout);

        left = 150;
        top = 430;

        numbers = new int[totalButtons];
        for (int k = 0; k < totalButtons; k++) {
            numbers[k] = k;
        }
        NumbersAfterPermutation = numbers;
        PlayerNumbers = new int[totalButtons];
        buttons = new Button[4][4];
        buttonsID = new int[4][4];
        startButtons();
        result = 0;
    }

    private void startButtons() {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                buttons[i][j] = new Button(this);
                buttons[i][j].setId(View.generateViewId());
                buttonsID[i][j] = buttons[i][j].getId();

                params = new
                        ConstraintLayout.LayoutParams(ConstraintLayout.LayoutParams.WRAP_CONTENT,
                        ConstraintLayout.LayoutParams.WRAP_CONTENT);
                params.width = buttonWidth;
                params.height = buttonHeight;
                buttons[i][j].setLayoutParams(params);
                constraintLayout.addView(buttons[i][j]);

                set = new ConstraintSet();
                set.clone(constraintLayout);
                if (j==0){
                    set.connect(buttons[i][j].getId(), ConstraintSet.LEFT, constraintLayout.getId(), ConstraintSet.LEFT,
                            left);
                }else {
                    set.connect(buttons[i][j].getId(), ConstraintSet.LEFT, buttons[i][j - 1].getId(), ConstraintSet.RIGHT,
                            0);
                }
                if (i == 0){
                    set.connect(buttons[i][j].getId(), ConstraintSet.TOP, constraintLayout.getId(), ConstraintSet.TOP,
                            top);
                }else {
                    set.connect(buttons[i][j].getId(), ConstraintSet.TOP, buttons[i - 1][j].getId(),
                            ConstraintSet.BOTTOM, 0);
                }
                set.applyTo(constraintLayout);
                buttons[i][j].setOnClickListener(buttonClickListener);
            }

        }
        numbersButtons();
    }

    private void numbersButtons(){
        String str;
        for (int i = 0; i< 4; i++){
            for (int j = 0; j< 4; j++){
                str = Integer.toString(NumbersAfterPermutation[i*4+j]);
                buttons[i][j].setText(str);
            }
        }
    }
    private void clearButtons(){
        for (int i = 0; i< 4; i++){
            for (int j = 0; j< 4; j++){
                if (buttonsID[i][j] == 0)
                    break;
                if (buttons[i][j] != null)
                    constraintLayout.removeView((Button)findViewById(buttonsID[i][j]));
            }
        }
    }

    private boolean checkWinCondition() {
        for (int i = 0; i < totalButtons - 1; i++) {
            if (NumbersAfterPermutation[i] != i + 1) {
                return false;
            }
        }
        return true;
    }

}