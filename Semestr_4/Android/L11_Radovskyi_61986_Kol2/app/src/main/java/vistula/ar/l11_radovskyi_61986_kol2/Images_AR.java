package vistula.ar.l11_radovskyi_61986_kol2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class Images_AR extends AppCompatActivity {

    TextView txtInfo;
    WorkWithMemory memory = new WorkWithMemory();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_images_ar);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        txtInfo = findViewById(R.id.txtInfo);
        txtInfo.setText(memory.readFromFile(this));
    }

    public void btnMemory(View view){
        Intent intent = new Intent(this, MemoryActivity_AR.class);
        startActivity(intent);
    }

    public void btnMain(View view){
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
    public void btnConvertor(View view){
        Intent intent = new Intent(this, ConvertorActivity_AR.class);
        startActivity(intent);
    }
}