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

public class ImageAK_Activity extends AppCompatActivity {

    EditText nameEditAK;
    EditText IDEditAK;
    Bundle pageInfoAK = new Bundle();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_image_ak);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        ExportData();
    }
    private void takeData(){
        nameEditAK = findViewById(R.id.editNameFifth);
        IDEditAK = findViewById(R.id.editNumberFifth);

        String nameMain = nameEditAK.getText().toString();
        String tikMain = IDEditAK.getText().toString();

        pageInfoAK.putString("Name",nameMain);
        pageInfoAK.putString("Tickets",tikMain);
    }

    public void ExportData(){
        Bundle bundle = getIntent().getExtras();
        String name = bundle.getString("Name");
        String ticketInfo = bundle.getString("Tickets");

        EditText nameText = (EditText) findViewById(R.id.editNameFifth);
        EditText tickets = (EditText) findViewById(R.id.editNumberFifth);

        nameText.setText(name);
        tickets.setText(ticketInfo);
    }

    public void btnMain(View view){
        takeData();

        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }
    public void btnThird(View view){
        takeData();

        Intent intent = new Intent(this, SplitAK_Activiry.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }
    public void btnGame(View view){
        takeData();

        Intent intent = new Intent(this, GameAK_Activity.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }
}