using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to generate traits for Female NPC's.
 */

public class XValue : MonoBehaviour {
    int age;
    int loyalty;

    string gender = "Female";
    string ethnicity;
    string sexID;
    string occupation;
    string religion;
    string maritalStatus;

    string[] jobList = new string[] {"Student",
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

    // Use this for initialization
    void Start() {

        /*
         * Generates age, ranges from 18 to 66.
         */
        age = Random.Range(18, 67);

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
            Random.Range(9, 11);
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
         *      Single - 48%
         *      Married - 52%
         */
        loyalty = Random.Range(1, 11);

        /*
         * Percentage of sexual identity:
         *      Heterosexual - 92%
         *      Non-heterosexual - 8%
         */
        if (Random.value <= 0.92) {
            sexID = "Straight";
        } else {
            sexID = "Homosexual";
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
         * Randomly chooses occupation.
         */
        occupation = jobList[Random.Range(0, 46)];

        /*
         * Prints all traits.
         */
        Debug.Log("Gender: " + gender + "\nAge: " + age + "\nEthnicity: " + ethnicity + "\nMarital Status: " + maritalStatus + "\nReligious Affiliation: " + religion
            + "\nSexual Orientation: " + sexID + "\nParty Loyalty (1-10): " + loyalty + "\nOccupation: " + occupation);
    }

    // Update is called once per frame
    void Update() {

    }
}