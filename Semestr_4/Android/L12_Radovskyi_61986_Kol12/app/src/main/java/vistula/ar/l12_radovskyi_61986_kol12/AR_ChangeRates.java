package vistula.ar.l12_radovskyi_61986_kol12;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class AR_ChangeRates extends AppCompatActivity {
    EditText USDtoJPY_AR;
    EditText USDtoGPB_AR;
    EditText JPYtoGPB_AR;
    EditText JPYtoUSD_AR;
    EditText GPBtoUSD_AR;
    EditText GPBtoJPY_AR;

    Bundle bundle = new Bundle();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_ar_change_rates);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

         USDtoJPY_AR = findViewById(R.id.usdJPY);
         USDtoGPB_AR = findViewById(R.id.usdGPB);
         JPYtoGPB_AR = findViewById(R.id.jpyGPB);
         JPYtoUSD_AR = findViewById(R.id.jpyUSD);
         GPBtoUSD_AR = findViewById(R.id.gpbUSD);
         GPBtoJPY_AR = findViewById(R.id.gpbJPY);
        ReadFromBundle();
        setRates();
    }

    public void ReadFromBundle(){
        Bundle bundle = getIntent().getExtras();

        String name = bundle.getString("Name");
        String surname = bundle.getString("Surname");

        EditText nameText = (EditText) findViewById(R.id.editNameC);
        EditText surnameText = (EditText) findViewById(R.id.editSurnameC);

        nameText.setText(name);
        surnameText.setText(surname);
    }
    public void btnGoToExchange(View view){
        putOnBundle();
        Intent intent = new Intent(this, AR_EchangeRatesActivity.class);
        intent.putExtras(bundle);
        startActivity(intent);
    }
    void putOnBundle(){
        EditText Name = (EditText)findViewById(R.id.editNameC);
        EditText Surname = (EditText) findViewById(R.id.editSurnameC);

        String nameB = Name.getText().toString();
        String surnameB = Surname.getText().toString();

        bundle.putString("Name", nameB);
        bundle.putString("Surname", surnameB);
    }

    public void btnSaveRates(View view){
        ExchangeRates.setUsdToJpy(Double.valueOf(USDtoJPY_AR.getText().toString()));
        ExchangeRates.setUsdToGbp(Double.valueOf(USDtoGPB_AR.getText().toString()));
        ExchangeRates.setGbpToUsd(Double.valueOf(GPBtoUSD_AR.getText().toString()));
        ExchangeRates.setJpyToUsd(Double.valueOf(JPYtoUSD_AR.getText().toString()));
        ExchangeRates.setGbpToJpy(Double.valueOf(GPBtoJPY_AR.getText().toString()));
        ExchangeRates.setJpyToGbp(Double.valueOf(JPYtoGPB_AR.getText().toString()));
        setRates();
    }
    private void setRates(){
        USDtoJPY_AR.setText(String.valueOf(ExchangeRates.convert(1,"USD","JPY")));
        USDtoGPB_AR.setText(String.valueOf(ExchangeRates.convert(1,"USD","GBP")));
        JPYtoGPB_AR.setText(String.valueOf(ExchangeRates.convert(1,"JPY","GBP")));
        JPYtoUSD_AR.setText(String.valueOf(ExchangeRates.convert(1,"JPY","USD")));
        GPBtoUSD_AR.setText(String.valueOf(ExchangeRates.convert(1,"GBP","USD")));
        GPBtoJPY_AR.setText(String.valueOf(ExchangeRates.convert(1,"GBP","JPY")));

    }
}