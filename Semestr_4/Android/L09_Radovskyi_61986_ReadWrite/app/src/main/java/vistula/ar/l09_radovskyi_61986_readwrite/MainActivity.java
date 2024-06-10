package vistula.ar.l09_radovskyi_61986_readwrite;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

public class MainActivity extends AppCompatActivity {
    String zapis = "zapis.txt";

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

    public void writeInternal(View view){
        EditText editText = (EditText)findViewById(R.id.editTxt);
        TextView textViewIn = (TextView)findViewById(R.id.txtIn);
        String str = editText.getText().toString();
        textViewIn.setText(str);
        textViewIn.setText(str);
        try {
            FileOutputStream fOut = openFileOutput(zapis, MODE_PRIVATE);
            OutputStreamWriter osw = new OutputStreamWriter(fOut);
            try {
                osw.write(str);
            }catch (IOException e){
                Toast.makeText(getBaseContext(),e.getMessage(),Toast.LENGTH_LONG).show();
            }
            osw.flush();
            osw.close();
        }
        catch (IOException e){
            Toast.makeText(getBaseContext(),e.getMessage(), Toast.LENGTH_LONG).show();
        }
    }

    public void readInternal(View view){
        TextView textViewOut = (TextView)findViewById(R.id.txtOut);
        int readBlockSize = 100;
        try {
            FileInputStream fin = openFileInput(zapis);
            InputStreamReader isr = new InputStreamReader(fin);
            char[] inputBuffer = new char[readBlockSize];
            String str = "";
            int charRead;
            while ((charRead = isr.read(inputBuffer))>0){
                String readString = String.copyValueOf(inputBuffer,0,charRead);
                str += readString;
                inputBuffer = new char[readBlockSize];
            }
            textViewOut.setText(str);
        }
        catch (IOException e){
            Toast.makeText(getBaseContext(),e.getMessage(),Toast.LENGTH_LONG).show();
        }
    }
}