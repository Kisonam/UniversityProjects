package vistula.rf.l14_fedoryka_62632_kol4;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.Random;

public class MainActivity extends AppCompatActivity {

    EditText nameEditRF, IdEditRF;
    TextView N1rf,N2rf;

    Bundle RFbundle = new Bundle();
    String RF_ID = "62632";
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

        try {
            OpenBundle();
        }
        catch (Exception ex){
           return;
        }
    }
    public void OpenBundle(){
        Bundle bundle = getIntent().getExtras();
        String name = bundle.getString("Name");
        String studId = bundle.getString("Number");

        EditText nameText = (EditText) findViewById(R.id.editNameMainRF);
        EditText idStud = (EditText) findViewById(R.id.editIDStudentRF);

        nameText.setText(name);
        idStud.setText(studId);
    }
    private void saveChanges(){
        nameEditRF = findViewById(R.id.editNameMainRF);
        IdEditRF = findViewById(R.id.editIDStudentRF);

        N1rf = findViewById(R.id.N1RF);
        N2rf = findViewById(R.id.N2RF);

        String nameMain = nameEditRF.getText().toString();
        String numOfId = IdEditRF.getText().toString();

        RFbundle.putString("Name",nameMain);
        RFbundle.putString("Number",numOfId);
    }
    public void btnGoSecondPage(View view){
        saveChanges();

        Intent intent = new Intent(this, RF_Activity2.class);
        intent.putExtras(RFbundle);
        startActivity(intent);
    }
    public void btnGoThirdPage(View view){
        saveChanges();

        Intent intent = new Intent(this, RF_Activity3.class);
        intent.putExtras(RFbundle);
        startActivity(intent);
    }
    public void btnGoForthPage(View view){
        saveChanges();

        Intent intent = new Intent(this, RF_Activity4.class);
        intent.putExtras(RFbundle);
        startActivity(intent);
    }
    public void btnGoFifthPage(View view){
        saveChanges();

        Intent intent = new Intent(this, RF_Activity5.class);
        intent.putExtras(RFbundle);
        startActivity(intent);
    }
    public void btnDraw(View view){
        saveChanges();
        String IDNowy = RF_ID.replaceAll("[01]", "");

        if (IDNowy.length() < 2) {
            N1rf.setText("Wpisz");
            N2rf.setText("poprawne liczbe");
            return;
        }

        int id1 = Character.getNumericValue(IDNowy.charAt(IDNowy.length() - 1));
        int id2 = Character.getNumericValue(IDNowy.charAt(IDNowy.length() - 2));
        Random rnd = new Random();
        int N1 = rnd.nextInt(id1);
        int N2 = rnd.nextInt(id2);

        N1rf.setText(String.valueOf(N1));
        N2rf.setText(String.valueOf(N2));
    }

}