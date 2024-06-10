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

public class RF_Activity4 extends AppCompatActivity {

    EditText nameEditRF, IdEditRF;
    Bundle RFbundle = new Bundle();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_rf4);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        OpenBundle();
    }
    public void OpenBundle(){
        Bundle bundle = getIntent().getExtras();
        String name = bundle.getString("Name");
        String studId = bundle.getString("Number");

        EditText nameText = (EditText) findViewById(R.id.editName4);
        EditText idStud = (EditText) findViewById(R.id.editNumber4);

        nameText.setText(name);
        idStud.setText(studId);
    }
    private void saveChanges(){
        nameEditRF = findViewById(R.id.editName4);
        IdEditRF = findViewById(R.id.editNumber4);

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