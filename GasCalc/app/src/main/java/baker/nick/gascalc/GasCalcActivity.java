package baker.nick.gascalc;

import android.app.Activity;
import android.os.Bundle;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.EditText;
import android.widget.Toast;
import android.view.View;
import android.widget.Button;

import com.google.ads.*;

public class GasCalcActivity extends Activity {
    /** Called when the activity is first created. */
	double miles, mpg, gPrice1, gPrice2, cost, cost1, gog, totalCost;

	EditText txtbox1, txtbox2, txtbox3, txtbox4;
	Button     button1;
	TextView tv;
	 private AdView adView;
	 String a14fcd84ef7ac7e;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);


        txtbox1=  (EditText) findViewById(R.id.txtbox1);
        txtbox2=  (EditText) findViewById(R.id.txtbox2);
        txtbox3 = (EditText) findViewById(R.id.txtbox3);
        txtbox4 = (EditText) findViewById(R.id.txtbox4);
        button1 = (Button) findViewById(R.id.button1);
        tv = (TextView) findViewById(R.id.tV1);

        button1.setOnClickListener(new clicker());
        AdView adView = (AdView)this.findViewById(R.id.adView);
        adView.loadAd(new AdRequest());

    }


    class  clicker implements Button.OnClickListener
    {
    public void onClick(View v)
       {
        String miles, mpg, gPrice1, gPrice2;
        Double gog, cost, cost1, totalCost, newCost, newCost1, newTotalCost;

        miles =  txtbox1.getText().toString();

        if(txtbox1.getText().toString().equals("")){
			Toast.makeText(v.getContext(), R.string.miles_not_filled, Toast.LENGTH_SHORT).show();
				return;
			}

        mpg =  txtbox2.getText().toString();

        if(txtbox2.getText().toString().equals("")){
			Toast.makeText(v.getContext(), R.string.mpg_not_filled, Toast.LENGTH_SHORT).show();
		          return;
			}

        gPrice1 = txtbox3.getText().toString();

        if(txtbox3.getText().toString().equals("")){
			Toast.makeText(v.getContext(), R.string.gasarea_not_filled, Toast.LENGTH_SHORT).show();
		          return;
			}

        gPrice2 = txtbox4.getText().toString();

        if(txtbox4.getText().toString().equals("")){
			Toast.makeText(v.getContext(), R.string.gasdest_not_filled, Toast.LENGTH_SHORT).show();
		          return;
			}

        gog =  (Double.parseDouble(miles)/Double.parseDouble(mpg));
        cost =  (gog*Double.parseDouble(gPrice1));
        cost1 = (gog*Double.parseDouble(gPrice2));
        totalCost = cost+cost1;
        newCost = Math.round(cost*100.0)/100.0;
        newCost1 = Math.round(cost1*100.0)/100.0;
        newTotalCost = Math.round(totalCost*100.0)/100.0;
        tv.setText("To go " + miles.toString() + " miles it will cost $"+ newCost + " USD. "+ "\n"+
        "And to come back it will cost $" + newCost1 + " USD. " +"\n"+
        		"In total it will cost you $"+ newTotalCost + " USD. " );

    }



public void doStart() {
	 BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	 System.out.println("How Many Miles Are You Going?");
	 //enter miles
	 try {
		miles =  Double.parseDouble(br.readLine());
	} catch (NumberFormatException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (IOException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	 //enter MPG
	 System.out.println("What is your car's MPG");
	 try {
		mpg = Double.parseDouble(br.readLine());
	} catch (NumberFormatException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (IOException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	 //gas calculations
	 System.out.println("Gas cost at starting point?");
	 try {
		gPrice1 = Double.parseDouble(br.readLine());
	} catch (NumberFormatException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (IOException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	 // Second gas calc
	 System.out.println("Gas cost at destination?");
	 try {
		gPrice2 = Double.parseDouble(br.readLine());
	} catch (NumberFormatException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (IOException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}

	// formulas for calculations
	 gog = (miles/mpg);
	 cost = (gog*gPrice1);
	cost1 = (gog*gPrice2);
	totalCost = cost + cost1;

	// Final message
	System.out.println(" To go " + miles + " miles it will cost " +cost+ " dollars USD ");
}
}
}
