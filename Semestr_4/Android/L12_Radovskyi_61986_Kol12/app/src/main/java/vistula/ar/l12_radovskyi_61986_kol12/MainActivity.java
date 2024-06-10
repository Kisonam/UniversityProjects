package vistula.ar.l12_radovskyi_61986_kol12;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    Bundle ARbundle = new Bundle();
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

    void putOnBundle(){
        EditText Name = (EditText)findViewById(R.id.etName);
        EditText Surname = (EditText) findViewById(R.id.etSurname);

        String nameB = Name.getText().toString();
        String surnameB = Surname.getText().toString();

        ARbundle.putString("Name", nameB);
        ARbundle.putString("Surname", surnameB);
    }
    public void btnSeeExchange(View view){
        putOnBundle();
        Intent intent = new Intent(this, AR_EchangeRatesActivity.class);
        intent.putExtras(ARbundle);
        startActivity(intent);
    }
    public void btnRates(View view){
        putOnBundle();
        Intent intent = new Intent(this, AR_ChangeRates.class);
        intent.putExtras(ARbundle);
        startActivity(intent);
    }
}