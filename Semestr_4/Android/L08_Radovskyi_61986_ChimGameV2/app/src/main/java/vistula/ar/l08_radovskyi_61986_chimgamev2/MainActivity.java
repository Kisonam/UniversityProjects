package vistula.ar.l08_radovskyi_61986_chimgamev2;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.constraintlayout.widget.ConstraintSet;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    int positions = 1;
    Boolean isStart = false;
    int[] numbers;
    int[] NumbersAfterPermutation;
    int[] PlayerNumbers;
    Button[][] buttons;
    int[][] buttonsID;
    int left, top, result;
    int currentButton, totalButtons;
    int rows, col;
    int buttonWidth = 250, buttonHeight = 200;
    ConstraintLayout constraintLayout;
    ConstraintLayout.LayoutParams params;
    ConstraintSet set;

    int[] numbersAfterPermutation;
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

    }

    final View.OnClickListener buttonClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Button b = (Button)view;
            if ((currentButton < totalButtons)&&(b.getText().toString().equals("*"))){
                b.setText(Integer.toString(positions));
                currentButton++;
                positions++;
            }
        }
    };

    public void DrawButton(View view) {
        if (!isStart)
            return;
        NumbersAfterPermutation = AlgorytmPermuntacji.shuffleFisherYeats(numbers);
        numbersButtons();
    }

    public void HideButton(View view) {
        if (!isStart)
            return;
        for (int i = 0; i< rows; i++){
            for (int j = 0; j< col; j++){
                buttons[i][j].setText("*");
            }
        }
        currentButton = 0;
    }

    private void InitializeButtons() {

        totalButtons = rows * col;
        constraintLayout = (ConstraintLayout) findViewById(R.id.constraintLayout);

        left = 20 * rows;
        top = 430;

        numbers = new int[totalButtons];
        for (int k = 0; k < totalButtons; k++) {
            numbers[k] = k+1;
        }
        NumbersAfterPermutation = numbers;
        PlayerNumbers = new int[totalButtons];
        buttons = new Button[rows][col];
        buttonsID = new int[rows][col];
        startButtons();
        result = 0;
    }

    private void startButtons() {
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < col; j++) {
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

    public void btnNewGame(View view){
        isStart = true;
        clearButtons();
        Spinner row = (Spinner) findViewById(R.id.spinerRow);
        Spinner column = (Spinner) findViewById(R.id.spinerCol);

        rows = row.getSelectedItemPosition() +1;
        col = column.getSelectedItemPosition() + 1;
        InitializeButtons();
    }
    private void numbersButtons(){
        String str;
        for (int i = 0; i< rows; i++){
            for (int j = 0; j< col; j++){
                str = Integer.toString(NumbersAfterPermutation[i*col+j]);
                buttons[i][j].setText(str);
            }
        }
    }

    public void ResultButton(View view) {
        if (!isStart)
            return;

        Button button;
        result = 0;
        try {
            for (int i = 0; i< rows; i++){
                for (int j = 0; j< col; j++){
                    button = (Button)findViewById(buttonsID[i][j]);
                    String strNumber = button.getText().toString();
                    PlayerNumbers[i* col +j] = Integer.parseInt(strNumber);
                    result += (PlayerNumbers[i * col +j] == NumbersAfterPermutation[i* col +j])?1:0;
                }
            }
        }
        catch (Exception exception){
            for (int i = 0; i< rows; i++){
                for (int j = 0; j< col; j++){
                    button = (Button)findViewById(buttonsID[i][j]);
                    String strNumber = button.getText().toString();
                    if (strNumber.isEmpty())
                        PlayerNumbers[i* col +j] = 0;
                    result += (PlayerNumbers[i * col +j] == NumbersAfterPermutation[i* col +j])?1:0;
                }
            }
        }

        TextView textViewResult = (TextView)findViewById(R.id.txtResultId);
        textViewResult.setText(Integer.toString(result));


        for (int i = 0; i< rows; i++){
            for (int j = 0; j< col; j++){
                button = (Button)findViewById(buttonsID[i][j]);
                String strResult = Integer.toString(NumbersAfterPermutation[i* col +j]) + ","
                        +Integer.toString(PlayerNumbers[i* col +j]);
                button.setText(strResult);
            }
        }
    }

    private void clearButtons(){
        for (int i = 0; i< rows; i++){
            for (int j = 0; j< col; j++){
                if (buttonsID[i][j] == 0)
                    break;
                constraintLayout.removeView((Button)findViewById(buttonsID[i][j]));
            }
        }
    }

    public void skipBtn(View view){
        positions++;
    }
}