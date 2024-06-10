package vistula.ar.l12_radovskyi_61986_kol12;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class AR_EchangeRatesActivity extends AppCompatActivity {

    Bundle bundle = new Bundle();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_ar_echange_rates);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        ReadFromBundle();
        setRates();
    }

    public void ReadFromBundle(){
        Bundle bundle = getIntent().getExtras();

        String name = bundle.getString("Name");
        String surname = bundle.getString("Surname");

        EditText nameText = (EditText) findViewById(R.id.editName);
        EditText surnameText = (EditText) findViewById(R.id.editSurname);

        nameText.setText(name);
        surnameText.setText(surname);
    }
    public void btnGoToExchange(View view){
        putOnBundle();
        Intent intent = new Intent(this, AR_ChangeRates.class);
        intent.putExtras(bundle);
        startActivity(intent);
    }
    void putOnBundle(){
        EditText Name = (EditText)findViewById(R.id.editName);
        EditText Surname = (EditText) findViewById(R.id.editSurname);

        String nameB = Name.getText().toString();
        String surnameB = Surname.getText().toString();

        bundle.putString("Name", nameB);
        bundle.putString("Surname", surnameB);
    }

    private void setRates(){
        TextView USDtoJPY = findViewById(R.id.txtUSDJPY);
        TextView USDtoGPB = findViewById(R.id.txtUSDGPB);
        TextView JPYtoGPB = findViewById(R.id.txtJPYGPB);
        TextView JPYtoUSD = findViewById(R.id.txtJPYUSD);
        TextView GPBtoUSD = findViewById(R.id.txtGPBUSD);
        TextView GPBtoJPY = findViewById(R.id.txtGPBJPY);

        USDtoJPY.setText(String.valueOf(ExchangeRates.convert(1,"USD","JPY")));
        USDtoGPB.setText(String.valueOf(ExchangeRates.convert(1,"USD","GBP")));
        JPYtoGPB.setText(String.valueOf(ExchangeRates.convert(1,"JPY","GBP")));
        JPYtoUSD.setText(String.valueOf(ExchangeRates.convert(1,"JPY","USD")));
        GPBtoUSD.setText(String.valueOf(ExchangeRates.convert(1,"GBP","USD")));
        GPBtoJPY.setText(String.valueOf(ExchangeRates.convert(1,"GBP","JPY")));

    }

}