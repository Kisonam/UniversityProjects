package vistula.ar.l07_radovskyi_61986_compass;

import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.os.Bundle;
import android.view.animation.Animation;
import android.view.animation.RotateAnimation;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity implements SensorEventListener {

    float azimuth_angle = 0f;
    float curent_azimuth_angle = 0f;
    float[] mGravity = new float[3];
    float[] mGeomagnetic = new float[3];
    private SensorManager compassSensor;
    Sensor accelerometer;
    Sensor magnetometer;
    TextView textViewAngle;
    ImageView imageViewCompass;


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

        compassSensor = (SensorManager)getSystemService(SENSOR_SERVICE);
        accelerometer = compassSensor.getDefaultSensor(Sensor.TYPE_ACCELEROMETER);
        magnetometer = compassSensor.getDefaultSensor(Sensor.TYPE_MAGNETIC_FIELD);
        textViewAngle = (TextView) findViewById(R.id.txtAngle);
        imageViewCompass = (ImageView) findViewById(R.id.imgCompass);
    }


    @Override
    public void onSensorChanged(SensorEvent event) {
        final float alpha = 0.97f;
        synchronized (this){
            if (event.sensor.getType() == Sensor.TYPE_ACCELEROMETER ){
                mGravity[0] = alpha * mGravity[0] + (1-alpha) * event.values[0];
                mGravity[1] = alpha * mGravity[1] + (1-alpha) * event.values[1];
                mGravity[2] = alpha * mGravity[2] + (1-alpha) * event.values[2];
            }
            if (event.sensor.getType() == Sensor.TYPE_MAGNETIC_FIELD ){
                mGeomagnetic[0] = alpha * mGeomagnetic[0] + (1-alpha) * event.values[0];
                mGeomagnetic[1] = alpha * mGeomagnetic[1] + (1-alpha) * event.values[1];
                mGeomagnetic[2] = alpha * mGeomagnetic[2] + (1-alpha) * event.values[2];
            }

            float R[] = new float[9];
            float I[] = new float[9];

            boolean success = SensorManager.getRotationMatrix(R,I,mGravity, mGeomagnetic);

            if (success){
                float Orientation[] = new float[3];
                SensorManager.getOrientation(R, Orientation);

                azimuth_angle = (float) Math.toDegrees(Orientation[0]);
                azimuth_angle = (azimuth_angle + 360) % 360;

                Animation anim = new RotateAnimation(-curent_azimuth_angle, -azimuth_angle, Animation.RELATIVE_TO_SELF,
                        0.5f, Animation.RELATIVE_TO_SELF, 0.5f);
                curent_azimuth_angle = azimuth_angle;

                anim.setDuration(5000);
                anim.setRepeatCount(0);
                anim.setFillAfter(true);

                imageViewCompass.startAnimation(anim);
            }

            textViewAngle.setText("Alpha = " + azimuth_angle);
        }
    }

    @Override
    public void onAccuracyChanged(Sensor sensor, int accuracy) {

    }

    @Override
    protected void onResume(){
        super.onResume();
        compassSensor.registerListener(this,accelerometer,SensorManager.SENSOR_DELAY_UI);
        compassSensor.registerListener(this,magnetometer,SensorManager.SENSOR_DELAY_UI);
    }
    @Override
    protected void onPause(){
        super.onPause();
        compassSensor.unregisterListener(this);
    }
}