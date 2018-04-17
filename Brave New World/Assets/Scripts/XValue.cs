using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XValue : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        string gender = "Female";
        Debug.Log(gender);

        int age = Random.Range(17, 53);
        Debug.Log(age);

        int loyalty = Random.Range(1, 11);
        Debug.Log("Party Loyalty: " + loyalty);

        string[] maritalStatus = new string[] { "Married", "Single" };
        Debug.Log(maritalStatus[Random.Range(0, 2)]);

        string[] sexID = new string[] { "Straight", "Homosexual" };
        if (Random.value <= 0.89) {
            Debug.Log(sexID[0]);
        } else {
            Debug.Log(sexID[1]);
        }

        string[] occupation = new string[] {"Student",
                                            "Refuse worker",
                                            "Musician",
                                            "Engineer",
                                            "Plant worker",
                                            "Programmer",
                                            "Teacher",
                                            "Professor",
                                            "Nanny",
                                            "Web content developer",
                                            "Chemical engineer",
                                            "Industrial engineer",
                                            "Network administrator",
                                            "Veteran (Active Duty)",
                                            "Veteran (Retired)",
                                            "Doctor",
                                            "Pilot",
                                            "Nurse",
                                            "Cashier",
                                            "Reporter",
                                            "Dentist",
                                            "Police officer",
                                            "Veterinarian",
                                            "Tech CEO",
                                            "Personal trainer",
                                            "Fast food worker",
                                            "Chef",
                                            "Waitress",
                                            "Retail worker",
                                            "Advertising consultant",
                                            "Lawyer",
                                            "Realtor",
                                            "Banker",
                                            "Stock broker",
                                            "Bus driver",
                                            "Bank teller",
                                            "Carpenter",
                                            "Therapist",
                                            "Chef - de - cuisine",
                                            "Retail manager",
                                            "Baker",
                                            "Salesperson",
                                            "Stylist",
                                            "Firefighter",
                                            "EMT",
                                            "Mechanic",
                                            "Politician"};
        Debug.Log("Occupation: " + occupation[Random.Range(0, 46)]);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}