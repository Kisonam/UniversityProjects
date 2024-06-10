package vistula.ar.l11_radovskyi_61986_kol2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class ConvertorActivity_AR extends AppCompatActivity {

    Spinner tempInfo;
    TextView txtCelAR, txtKelAR, txtFarAR, txtInfo;
    EditText tempNum;
    String temperature;
    String unit;

    WorkWithMemory memoryAR = new WorkWithMemory();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_convertor_ar);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        txtInfo = findViewById(R.id.txtInfoMem);
        txtInfo.setText(memoryAR.readFromFile(this));

        txtCelAR = findViewById(R.id.txtCelInfo);
        txtKelAR = findViewById(R.id.txtKelInfo);
        txtFarAR = findViewById(R.id.txtFahinfo);
        tempInfo = findViewById(R.id.spinnerTempAR);

        tempNum = findViewById(R.id.editTempAR);
    }

    public void btnConvert(View view){
        unit = tempInfo.getSelectedItem().toString();
        temperature = tempNum.getText().toString();

        convertTemperature( Double.valueOf(temperature), unit);
    }
    private void convertTemperature(double temperature, String unit) {
        double celsiusAR, fahrenheitAR, kelvinAR;

        switch (unit) {
            case "Celsius":
                celsiusAR = temperature;
                fahrenheitAR = celsiusAR * 9/5 + 32;
                kelvinAR = celsiusAR + 273.15;

                break;
            case "Fahrenheit":
                fahrenheitAR = temperature;
                celsiusAR = (fahrenheitAR - 32) * 5/9;
                kelvinAR = celsiusAR + 273.15;


                break;
            case "Kelvin":
                kelvinAR = temperature;
                celsiusAR = kelvinAR - 273.15;
                fahrenheitAR = celsiusAR * 9/5 + 32;


                break;
            default:
                celsiusAR = fahrenheitAR = kelvinAR = 0;
                break;
        }

        txtCelAR.setText(String.valueOf(celsiusAR));
        txtFarAR.setText(String.valueOf(fahrenheitAR));
        txtKelAR.setText(String.valueOf(kelvinAR));
    }

    public void btnGoMain(View view){
        Intent intent = new Intent(this, Images_AR.class);
        startActivity(intent);
    }
}