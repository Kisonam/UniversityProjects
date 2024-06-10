package vistula.ar.l11_radovskyi_61986_kol2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MemoryActivity_AR extends AppCompatActivity {

    TextView txtData;
    WorkWithMemory memory = new WorkWithMemory();

    TextView txtNameAr,txtSurnameAr;
    EditText editName, editSurname;
    String townAR, NameAr, SurnameAr;
    Spinner spinnerAR;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_memory_ar);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        txtData = findViewById(R.id.txtData);
        txtData.setText(memory.readFromFile(this));

        editName = findViewById(R.id.editName);
        editSurname = findViewById(R.id.editSurname);
    }

    public void btnGoMain(View view){
        Intent intent = new Intent(this, Images_AR.class);
        startActivity(intent);
    }

    public void btnSave(View view){
        spinnerAR = findViewById(R.id.spinnerTown);
        townAR = spinnerAR.getSelectedItem().toString();



        NameAr = txtNameAr.getText().toString();
        SurnameAr = txtSurnameAr.getText().toString();

        memory.saveToFile(this,NameAr, SurnameAr, townAR);
        txtData.setText(memory.readFromFile(this));
    }

}