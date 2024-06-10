package vistula.ak.l14_kuchynska_61914_kol4;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class DataAK_Activity extends AppCompatActivity {

    EditText nameEditAK;
    EditText IDEditAK;
    Bundle pageInfoAK = new Bundle();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_data_ak);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        ExportData();
    }

    public void ExportData(){
        Bundle bundle = getIntent().getExtras();
        String name = bundle.getString("Name");
        String tick = bundle.getString("Tickets");

        EditText nameText = (EditText) findViewById(R.id.editNameSecond);
        EditText tickets = (EditText) findViewById(R.id.editTicketSecond);

        nameText.setText(name);
        tickets.setText(tick);
    }
    private void takeData(){
        nameEditAK = findViewById(R.id.editNameSecond);
        IDEditAK = findViewById(R.id.editTicketSecond);

        String nameMain = nameEditAK.getText().toString();
        String tikMain = IDEditAK.getText().toString();

        pageInfoAK.putString("Name",nameMain);
        pageInfoAK.putString("Tickets",tikMain);

    }
    public void btnMain(View view){
        takeData();

        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }
}