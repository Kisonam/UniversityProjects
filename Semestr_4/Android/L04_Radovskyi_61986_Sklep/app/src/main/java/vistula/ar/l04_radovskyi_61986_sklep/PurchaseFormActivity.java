package vistula.ar.l04_radovskyi_61986_sklep;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

public class PurchaseFormActivity extends AppCompatActivity {
    int howMany;
    int[] txtEditDataId, txtIdCost;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_purchase_form);
        readFromIntent();
    }

    private void readFromIntent(){
        Bundle bundle = getIntent().getExtras();

        String name = bundle.getString("name");
        String town = bundle.getString("town");
        howMany = bundle.getInt("howMany");

        EditText nameText = (EditText) findViewById(R.id.txtEditName);
        EditText townText = (EditText) findViewById(R.id.txtEditTown);

        nameText.setText(name);
        townText.setText(town);


        txtEditDataId = new int[howMany];
        txtIdCost = new int[howMany];
        form(howMany);
    }
    private void form(int rows){
        LinearLayout linearLayoutMain = (LinearLayout) findViewById(R.id.linearLayoutMain);

        for (int i = 0; i < rows; i++){
            LinearLayout layoutRow = new LinearLayout(this);
            LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(
                    ViewGroup.LayoutParams.MATCH_PARENT,
                    ViewGroup.LayoutParams.WRAP_CONTENT);

            layoutRow.setLayoutParams(params);
            layoutRow.setOrientation(LinearLayout.HORIZONTAL);

            // Data code
            TextView textViewData = new TextView(this);
            textViewData.setText(getResources().getString(R.string.txtData));
            layoutRow.addView(textViewData);

            EditText editTextData = new EditText(this);
            editTextData.setId(View.generateViewId());
            txtEditDataId[i] = editTextData.getId();

            editTextData.setHint(getResources().getString(R.string.hintData));
            editTextData.setGravity(Gravity.CENTER_HORIZONTAL);

            layoutRow.addView(editTextData);

            // Cost code
            TextView textViewCost= new TextView(this);
            textViewCost.setText(getResources().getString(R.string.txtCost));
            layoutRow.addView(textViewCost);

            EditText editTextCost = new EditText(this);
            editTextCost.setId(View.generateViewId());
            txtIdCost[i] = editTextCost.getId();

            editTextCost.setHint(getResources().getString(R.string.hintCost));
            editTextCost.setGravity(Gravity.CENTER_HORIZONTAL);

            layoutRow.addView(editTextCost);

            linearLayoutMain.addView(layoutRow);
        }
    }
    public void purchase(View view){
        Bundle bundle = new Bundle();
        TextView textViewData = new TextView(this);
        TextView textViewCost = new TextView(this);

        for(int i= 0; i < howMany; i++){
            textViewData = (TextView) findViewById(txtEditDataId[i]);
            bundle.putString("Data",textViewData.toString());

            textViewCost = (TextView) findViewById(txtIdCost[i]);
            bundle.putString("Cost", textViewCost.toString());
        }

        Intent intent = new Intent(this, SummaryFormActivity.class);
        intent.putExtras(bundle);
        startActivity(intent);
    }
}