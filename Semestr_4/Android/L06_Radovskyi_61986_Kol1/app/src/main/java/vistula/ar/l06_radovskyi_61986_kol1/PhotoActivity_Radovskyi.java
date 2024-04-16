package vistula.ar.l06_radovskyi_61986_kol1;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class PhotoActivity_Radovskyi extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_photo_radovskyi);
        ReadFromBundle();

    }

    public void ReadFromBundle(){
        Bundle bundle = getIntent().getExtras();

        String name = bundle.getString("Name");
        String surname = bundle.getString("Surname");

        EditText nameText = (EditText) findViewById(R.id.txtEditNamePhoto);
        EditText surnameText = (EditText) findViewById(R.id.txtSurnamePhoto);

        nameText.setText(name);
        surnameText.setText(surname);
    }

    public void btnMain(View view){
        Intent intent = new Intent(this, MainActivity.class);

        startActivity(intent);
    }
}