package vistula.ar.l04_radovskyi_61986_sklep;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Spinner;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void purchaseForm(View view) {
        EditText editTextName = (EditText) findViewById(R.id.txtEditNameMain);
        EditText editTextTown = (EditText) findViewById(R.id.txtEditTownMain);

        Spinner spinner = (Spinner) findViewById(R.id.spinnerHowMany);
        String name = editTextName.getText().toString();
        String town = editTextTown.getText().toString();
        Integer howMany = spinner.getSelectedItemPosition()+1;

        Bundle bundle = new Bundle();
        bundle.putString("name", name);
        bundle.putString("town", town);
        bundle.putInt("howMany",howMany);

        Intent intent = new Intent(this, PurchaseFormActivity.class);
        intent.putExtras(bundle);
        startActivity(intent);

    }
}