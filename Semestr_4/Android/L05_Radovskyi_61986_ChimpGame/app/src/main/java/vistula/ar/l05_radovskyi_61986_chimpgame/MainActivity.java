package vistula.ar.l05_radovskyi_61986_chimpgame;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.constraintlayout.widget.ConstraintSet;

import android.os.Bundle;
import android.os.PersistableBundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    int[] numbers;
    int[] NumbersAfterPermutation;
    int[] PlayerNumbers;
    Button[][] buttons;
    int[][] buttonsID;
    int sideButtons, left, top, totalButtons, result, currentButton;

    ConstraintLayout constraintLayout;
    ConstraintLayout.LayoutParams params;
    ConstraintSet set;

    int[] numbersAfterPermutation;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        InitializeButtons();
    }


    final View.OnClickListener buttonClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Button b = (Button)view;
            if ((currentButton < totalButtons)&&(b.getText().toString().equals("*"))){
                b.setText(Integer.toString(++currentButton));
            }
        }
    };

    public void DrawButton(View view) {
        NumbersAfterPermutation = AlgorytmPermuntacji.shuffleFisherYeats(numbers);
        numbersButtons();
    }

    public void HideButton(View view) {
        for (int i = 0; i< sideButtons; i++){
            for (int j = 0; j< sideButtons; j++){
                buttons[i][j].setText("*");
            }
        }
        currentButton = 0;
    }

    private void InitializeButtons() {
        sideButtons = 3;
        int totalButtons = sideButtons * sideButtons;
        constraintLayout = (ConstraintLayout) findViewById(R.id.constraintLayout);

        left = 120;
        top = 330;

        numbers = new int[totalButtons];
        for (int k = 0; k < totalButtons; k++) {
            numbers[k] = k+1;
        }
        NumbersAfterPermutation = numbers;
        PlayerNumbers = new int[totalButtons];
        buttons = new Button[sideButtons][sideButtons];
        buttonsID = new int[sideButtons][sideButtons];
        startButtons(); //tworzy tablicę przycisków
        result = 0;
    }

    private void startButtons() {
        for (int i = 0; i < sideButtons; i++) {
            for (int j = 0; j < sideButtons; j++) {
                buttons[i][j] = new Button(this);
                buttons[i][j].setId(View.generateViewId());
                buttonsID[i][j] = buttons[i][j].getId();

                params = new
                        ConstraintLayout.LayoutParams(ConstraintLayout.LayoutParams.WRAP_CONTENT,
                        ConstraintLayout.LayoutParams.WRAP_CONTENT);
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
                buttons[i][j].setOnClickListener(buttonClickListener); //dodanie listenera
            }

        }
        numbersButtons();
    }



    private void numbersButtons(){
        String str;
        for (int i = 0; i< sideButtons; i++){
            for (int j = 0; j< sideButtons; j++){
                str = Integer.toString(NumbersAfterPermutation[i*sideButtons+j]);
                buttons[i][j].setText(str);
            }
        }
    }

    public void ResultButton(View view) {
        Button button;
        result = 0;
        for (int i = 0; i< sideButtons; i++){
            for (int j = 0; j< sideButtons; j++){
                button = (Button)findViewById(buttonsID[i][j]);
                String strNumber = button.getText().toString();
                PlayerNumbers[i* sideButtons +j] = Integer.parseInt(strNumber);
                result += (PlayerNumbers[i* sideButtons +j] == NumbersAfterPermutation[i* sideButtons +j])?1:0;
            }
        }
        TextView textViewResult = (TextView)findViewById(R.id.txtResultId);
        textViewResult.setText(Integer.toString(result));


        for (int i = 0; i< sideButtons; i++){
            for (int j = 0; j< sideButtons; j++){
                button = (Button)findViewById(buttonsID[i][j]);
                String strResult = Integer.toString(NumbersAfterPermutation[i* sideButtons +j]) + ","
                        +Integer.toString(PlayerNumbers[i* sideButtons +j]);
                button.setText(strResult);
            }
        }
    }

}