package vistula.rf.l14_fedoryka_62632_kol4;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class RF_Activity3 extends AppCompatActivity {

    EditText nameEditRF, IdEditRF;

    EditText EditRF1, EditRF2, EditRF3;

    Bundle RFbundle = new Bundle();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_rf3);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        OpenBundle();

        EditRF1 = findViewById(R.id.editSplit1);
        EditRF2 = findViewById(R.id.editSplit2);
        EditRF3 = findViewById(R.id.editSplit3);

        EditRF1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditRF1.setText(EditRF2.getText().toString() + EditRF3.getText().toString());
            }
        });

        EditRF2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditRF2.setText(EditRF1.getText().toString() + EditRF3.getText().toString());
            }
        });

        EditRF3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditRF3.setText(EditRF1.getText().toString() + EditRF2.getText().toString());
            }
        });
    }

    public void OpenBundle(){
        Bundle bundle = getIntent().getExtras();
        String name = bundle.getString("Name");
        String studId = bundle.getString("Number");

        EditText nameText = (EditText) findViewById(R.id.editName3);
        EditText idStud = (EditText) findViewById(R.id.editID3);

        nameText.setText(name);
        idStud.setText(studId);
    }
    private void saveChanges(){
        nameEditRF = findViewById(R.id.editName3);
        IdEditRF = findViewById(R.id.editID3);

        String nameMain = nameEditRF.getText().toString();
        String numOfId = IdEditRF.getText().toString();

        RFbundle.putString("Name",nameMain);
        RFbundle.putString("Number",numOfId);
    }

    public void btnMain(View view){
        saveChanges();

        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtras(RFbundle);
        startActivity(intent);
    }
}