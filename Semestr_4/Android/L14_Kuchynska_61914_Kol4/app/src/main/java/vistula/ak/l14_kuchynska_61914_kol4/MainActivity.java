package vistula.ak.l14_kuchynska_61914_kol4;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
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

    EditText nameEditAK;
    EditText IDEditAK;
    Bundle pageInfoAK = new Bundle();
    TextView txtN1AK,txtN2AK;

    private final String ID = "61914";
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
        takeData();
        generateRandomNumbers();
        try {
            ExportData();
        }
        catch (Exception ex){
            Log.d("ex",ex.toString());
        }
    }

    private void takeData(){
        nameEditAK = findViewById(R.id.editNameAK);
        IDEditAK = findViewById(R.id.editIDMainAK);

        txtN1AK = findViewById(R.id.N1Num);
        txtN2AK = findViewById(R.id.N2Num);

        String nameMain = nameEditAK.getText().toString();
        String tikMain = IDEditAK.getText().toString();

        pageInfoAK.putString("Name",nameMain);
        pageInfoAK.putString("Tickets",tikMain);

    }
    public void btnGoActivity2(View view){
        takeData();

        Intent intent = new Intent(this, DataAK_Activity.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }

    public void ExportData(){
        Bundle bundle = getIntent().getExtras();
        String name = bundle.getString("Name");
        String ticketInfo = bundle.getString("Tickets");

        EditText nameText = (EditText) findViewById(R.id.editNameAK);
        EditText tickets = (EditText) findViewById(R.id.editIDMainAK);

        nameText.setText(name);
        tickets.setText(ticketInfo);
    }
    public void btnGoActivity3(View view){
        takeData();

        Intent intent = new Intent(this, SplitAK_Activiry.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }
    public void btnGoActivity4(View view){
        takeData();

        Intent intent = new Intent(this, GameAK_Activity.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }
    public void btnGoActivity5(View view){
        takeData();

        Intent intent = new Intent(this, ImageAK_Activity.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }

    public void btnDraw(View view){
        takeData();
        generateRandomNumbers();

    }

    private void generateRandomNumbers() {
        String IDNowy = ID.replaceAll("[01]", "");

        if (IDNowy.length() < 2) {
            txtN1AK.setText("EROOR");
            txtN2AK.setText("ERROR");
            return;
        }

        int id1 = Character.getNumericValue(IDNowy.charAt(IDNowy.length() - 1));
        int id2 = Character.getNumericValue(IDNowy.charAt(IDNowy.length() - 2));

        Random rnd = new Random();
        int N1 = rnd.nextInt(id1);
        int N2 = rnd.nextInt(id2);

        txtN1AK.setText(String.valueOf(N1));
        txtN2AK.setText(String.valueOf(N2));
    }
}