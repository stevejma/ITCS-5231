using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traits : MonoBehaviour {

    public GameObject NPC;

    public int age;
    public int loyalty;

    public string gender;
    public string ethnicity;
    public string sexID;
    public string occupation;
    public string religion;
    public string maritalStatus;

    string[] jobListX = new string[] {"Student",
                                     "Hospice worker",
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
                                     "Pharmacist",
                                     "Politician"};

    string[] jobListY = new string[] {"Student",
                                     "Refuse worker",
                                     "Musician",
                                     "Engineer",
                                     "Plant worker",
                                     "Programmer",
                                     "Teacher",
                                     "Professor",
                                     "Electrician",
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
                                     "Truck driver",
                                     "Tech CEO",
                                     "Personal trainer",
                                     "Fast food worker",
                                     "Chef",
                                     "Waiter",
                                     "Retail worker",
                                     "Advertising consultant",
                                     "Lawyer",
                                     "Realtor",
                                     "Banker",
                                     "Stock broker",
                                     "Bus driver",
                                     "Plumber",
                                     "Carpenter",
                                     "Construction worker",
                                     "Chef - de - cuisine",
                                     "Retail manager",
                                     "Baker",
                                     "Salesperson",
                                     "Machinist",
                                     "Firefighter",
                                     "EMT",
                                     "Mechanic",
                                     "Politician"};

    // Use this for initialization
    void Start()
    {
        if (NPC.tag == "xNPC") {
            gender = "Female";

            /*
             * Randomly chooses occupation for "Female".
             */
            occupation = jobListX[Random.Range(0, 46)];

            /*
             * Percentage of sexual identity:
             *      Heterosexual - 92%
             *      Non-heterosexual - 8%
             */
            if (Random.value <= 0.92) {
                sexID = "Straight";
            } else if (Random.value <= 0.94) {
                sexID = "Homosexual";
            } else {
                sexID = "Homosexual Tendencies";
            }
        } else if (NPC.tag == "yNPC") {
            gender = "Male";

            /*
             * Randomly chooses occupation for "Male".
             */
            occupation = jobListY[Random.Range(0, 46)];

            /*
             * Percentage of sexual identity:
             *      Heterosexual - 95%
             *      Non-heterosexual - 5%
             */
            if (Random.value <= 0.95) {
                sexID = "Straight";
            } else if (Random.value <= 0.975) {
                sexID = "Homosexual";
            } else {
                sexID = "Homosexual Tendencies";
            }
        }


        /*
         * Generates age, ranges from 18 to 62.
         */
        age = Random.Range(18, 63);

        /*
         * Ruling Party favorability percentages from 1 (least favorable) to 10 (most favorable)
         *      Least favorable (1-2) - 10%
         *      Unfavorable (3-4) - 18%
         *      Indifferent (5-6) - 37%
         *      Favorable (7-8) - 29%
         *      Most favorable (9-10) - 6%
         */
        if (Random.value <= 0.10) {
            loyalty = Random.Range(1, 3);
        } else if (Random.value <= 0.28) {
            loyalty = Random.Range(3, 5);
        } else if (Random.value <= 0.65) {
            loyalty = Random.Range(5, 7);
        } else if (Random.value <= 0.94) {
            loyalty = Random.Range(7, 9);
        } else {
            loyalty = Random.Range(9, 11);
        }

        /*
         * Race and ethnicity demographics:
         *      White - 64%
         *      Hispanic/Latino - 16%
         *      Black - 12%
         *      American Indian - 1%
         *      Asian - 5%
         *      Other - 2%     
         */
        if (Random.value <= 0.01) {
            ethnicity = "American Indian";
        } else if (Random.value <= 0.03) {
            ethnicity = "Other";
        } else if (Random.value <= 0.08) {
            ethnicity = "Asian";
        } else if (Random.value <= 0.2) {
            ethnicity = "Black";
        } else if (Random.value <= 0.36) {
            ethnicity = "Hispanic/Latino";
        } else {
            ethnicity = "White";
        }

        /*
         * Percentage of marital status:
         *      Married - 52%
         *      Single - 48%
         */
        if (Random.value <= 0.52) {
            maritalStatus = "Married";
        } else {
            maritalStatus = "Single";
        }

        /*
         * Demographics breakdown for religion:
         *      Christianity - 70%
         *      Nonreligious - 24%
         *      Jewish - 2%
         *      Muslim - 1%
         *      Bhuddish - 1%
         *      Hindu - 1%
         *      Other non-Christian - 1%  
         */
        if (Random.value <= 0.01) {
            religion = "Hindu";
        } else if (Random.value <= 0.02) {
            religion = "Bhuddist";
        } else if (Random.value <= 0.03) {
            religion = "Other non-Christian";
        } else if (Random.value <= 0.04) {
            religion = "Muslim";
        } else if (Random.value <= 0.06) {
            religion = "Jewish";
        } else if (Random.value <= 0.30) {
            religion = "Nonreligious";
        } else {
            religion = "Christianity";
        }


        /*
         * Prints all traits.
         */
        Debug.Log("Gender: " + gender +
                  "\nAge: " + age +
                  "\nEthnicity: " + ethnicity +
                  "\nMarital Status: " + maritalStatus +
                  "\nReligious Affiliation: " + religion +
                  "\nSexual Orientation: " + sexID +
                  "\nParty Loyalty (1-10): " + loyalty +
                  "\nOccupation: " + occupation);
    }

    public string Storing() {
        string output = ("Gender: " + gender +
                        "\nAge: " + age +
                        "\nEthnicity: " + ethnicity +
                        "\nMarital Status: " + maritalStatus +
                        "\nReligious Affiliation: " + religion +
                        "\nSexual Orientation: " + sexID +
                        "\nParty Loyalty (1-10): " + loyalty +
                        "\nOccupation: " + occupation);

        return output;

    }
}