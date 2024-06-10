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

public class GameAK_Activity extends AppCompatActivity {

    EditText nameEditAK;
    EditText IDEditAK;
    Bundle pageInfoAK = new Bundle();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_game_ak);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        ExportData();
    }

    private void takeData(){
        nameEditAK = findViewById(R.id.editNameGame);
        IDEditAK = findViewById(R.id.editTicketGame);

        String nameMain = nameEditAK.getText().toString();
        String tikMain = IDEditAK.getText().toString();

        pageInfoAK.putString("Name",nameMain);
        pageInfoAK.putString("Tickets",tikMain);
    }

    public void ExportData(){
        Bundle bundle = getIntent().getExtras();
        String name = bundle.getString("Name");
        String ticketInfo = bundle.getString("Tickets");

        EditText nameText = (EditText) findViewById(R.id.editNameGame);
        EditText tickets = (EditText) findViewById(R.id.editTicketGame);

        nameText.setText(name);
        tickets.setText(ticketInfo);
    }

    public void btnMain(View view){
        takeData();

        Intent intent = new Intent(this, MainActivity.class);
        intent.putExtras(pageInfoAK);
        startActivity(intent);
    }
}