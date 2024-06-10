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

public class SplitAK_Activiry extends AppCompatActivity {

    EditText text1AK, text2AK, text3AK;
    EditText nameEditAK;
    EditText IDEditAK;
    Bundle pageInfoAK = new Bundle();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_split_ak_activiry);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        ExportData();
        setEdit();
    }

    private void setEdit(){
        text1AK = findViewById(R.id.edit1);
        text2AK = findViewById(R.id.edit2);
        text3AK = findViewById(R.id.edit3);

        text1AK.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                text1AK.setText(text2AK.getText().toString() + text3AK.getText().toString());
            }
        });

        text2AK.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                text2AK.setText(text1AK.getText().toString() + text3AK.getText().toString());
            }
        });

        text3AK.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                text3AK.setText(text1AK.getText().toString() + text2AK.getText().toString());
            }
        });
    }
    private void takeData(){
        nameEditAK = findViewById(R.id.editNameThird);
        IDEditAK = findViewById(R.id.editTicketThird);

        String nameMain = nameEditAK.getText().toString();
        String tikMain = IDEditAK.getText().toString();

        pageInfoAK.putString("Name", nameMain);
        pageInfoAK.putString("Tickets", tikMain);

    }

    public void ExportData(){
        Bundle bundle = getIntent().getExtras();
        String name = bundle.getString("Name");
        String tick = bundle.getString("Tickets");

        EditText nameText = (EditText) findViewById(R.id.editNameThird);
        EditText ticket = (EditText) findViewById(R.id.editTicketThird);

        nameText.setText(name);
        ticket.setText(tick);
    }
    public void btnMain(View view){
        takeData();

        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }
}