package vistula.ar.l06_radovskyi_61986_kol1;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    Bundle bundle = new Bundle();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


    }

    void putOnBundle(){
        EditText Name = (EditText)findViewById(R.id.txtFirstName);
        EditText Surname = (EditText) findViewById(R.id.txtSurname);

        String nameB = Name.getText().toString();
        String surnameB = Surname.getText().toString();

        bundle.putString("Name", nameB);
        bundle.putString("Surname", surnameB);
    }
    public void btnStartGame(View view){
        putOnBundle();
        Intent intent = new Intent(this, GameActivity_Radovskyi.class);
        intent.putExtras(bundle);
        startActivity(intent);
    }

    public void btnCalculator(View view){
        putOnBundle();
        Intent intent = new Intent(this, CalculatorActity_Radovskyi.class);
        intent.putExtras(bundle);
        startActivity(intent);
    }
    public void btnSeePhoto(View view){
        putOnBundle();
        Intent intent = new Intent(this, PhotoActivity_Radovskyi.class);
        intent.putExtras(bundle);
        startActivity(intent);
    }


}