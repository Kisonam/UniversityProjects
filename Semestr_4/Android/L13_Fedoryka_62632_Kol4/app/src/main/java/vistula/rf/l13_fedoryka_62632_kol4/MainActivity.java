package vistula.rf.l13_fedoryka_62632_kol4;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    EditText nameEditRF;
    EditText surnameEditRF;
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


    }

    private void takeData(){
        nameEditRF = findViewById(R.id.editNameMainRF);
        surnameEditRF = findViewById(R.id.editSurnameMainRF);

        String nameMain = nameEditRF.getText().toString();
        String surnameMain = surnameEditRF.getText().toString();
    }
    public void btnGoNextPage(View view){
        takeData();
    }
}