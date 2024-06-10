package vistula.ar.l11_radovskyi_61986_kol2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;


public class MainActivity extends AppCompatActivity {


    TextView txtNameAr,txtSurnameAr, txtInfo;
    String townAR, NameAr, SurnameAr;
    Spinner spinnerAR;
    WorkWithMemory memoryAR = new WorkWithMemory();
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
        memoryAR.createMemoryFile(this);
    }



    public void btnGoToImg(View view){
        Intent intent = new Intent(this, Images_AR.class);
        startActivity(intent);
    }

    public void btnSaveToMemory(View view){
        txtNameAr = (TextView) findViewById(R.id.editNameAR);
        txtSurnameAr = (TextView) findViewById(R.id.editSurnameAR);
        spinnerAR = findViewById(R.id.spinerTownsAR);
        townAR = spinnerAR.getSelectedItem().toString();

        NameAr = txtNameAr.getText().toString();
        SurnameAr = txtSurnameAr.getText().toString();

        memoryAR.saveToFile(this,NameAr, SurnameAr, townAR);
        txtInfo = findViewById(R.id.txtMemoryAR);
        txtInfo.setText(memoryAR.readFromFile(this));

    }
}