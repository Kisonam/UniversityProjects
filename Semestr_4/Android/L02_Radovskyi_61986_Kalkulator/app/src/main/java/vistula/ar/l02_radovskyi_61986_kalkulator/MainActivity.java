package vistula.ar.l02_radovskyi_61986_kalkulator;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void calculate(View view){
        EditText editTextNum1 = (EditText) findViewById(R.id.inputNumber1);
        EditText editTextNum2 = (EditText) findViewById(R.id.inputNumber2);
        Spinner spinnerBase1 = (Spinner) findViewById(R.id.spinnerBase1);
        Spinner spinnerBase2 = (Spinner) findViewById(R.id.spinnerBase2);
        Spinner spinnerOperator = (Spinner) findViewById(R.id.spinnerOperator);
        TextView textViewOutput1 = (TextView) findViewById(R.id.outputBase1);
        TextView textViewOutputBase10 = (TextView) findViewById(R.id.txtOutputBase10);

        String str_n1 = editTextNum1.getText().toString();
        String str_n2 = editTextNum2.getText().toString();
        int base1 = Integer.parseInt(spinnerBase1.getSelectedItem().toString());
        int base2 = Integer.parseInt(spinnerBase2.getSelectedItem().toString());
        String operator = spinnerOperator.getSelectedItem().toString();

        int n1 = 0, n2 = 0;

        try {
            n1 = Integer.parseInt(str_n1, base1);
        }
        catch (NumberFormatException e){
            editTextNum1.setText("0");
        }
        try {
            n2 = Integer.parseInt(str_n2, base1);
        }
        catch (NumberFormatException e){
            editTextNum2.setText("0");
        }

        int result = 0;

        result = CalculateTools.calculateTools(n1, n2, operator);

        textViewOutputBase10.setText(Integer.toString(result));
        textViewOutput1.setText(Integer.toString(result, base1).toUpperCase());

        TextView textViewNumber1Base10 = (TextView)findViewById(R.id.txtInputNum1Base10);
        TextView textViewOperatorBase10= (TextView)findViewById(R.id.txtOperator10);
        TextView textViewNumber2Base10 = (TextView)findViewById(R.id.txtInputNum2Base10);
        TextView textViewNumber1Base2 = (TextView)findViewById(R.id.txtInputNumber1Base2);
        TextView OutputBase2= (TextView)findViewById(R.id.txtOutputBase2);
        TextView Operator = (TextView)findViewById(R.id.textView13);

        TextView textViewNumber2Base2 = (TextView)findViewById(R.id.txtInputNumber2Base2);

        textViewNumber1Base10.setText(Integer.toString(n1));
        textViewOperatorBase10.setText(operator);
        textViewNumber2Base10.setText(Integer.toString(n2));

        textViewNumber1Base2.setText(Integer.toString(n1, base2));
        textViewNumber2Base2.setText(Integer.toString(n2, base2));
        Operator.setText(operator);
        OutputBase2.setText(Integer.toString(result, base2));

    }
}