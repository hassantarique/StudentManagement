#include <iostream>
#include <fstream>
#include <string>
using namespace std;

class Event {
private:
    int eventId[100];
    string eventName[100];
    string eventDate[100];
    string eventTime[100];
    string eventVenue[100];
    string eventDescription[100];
    int eventCount;

public:
    Event() {
        eventCount = 0;
        loadEvents();
    }

    void addEvent() {
        if (eventCount >= 100) {
            cout << "Error: Event limit reached." << endl;
            return;
        }

        int id;
        cout << "Enter Event ID: ";
        cin >> id;

        for (int i = 0; i < eventCount; i++) {
            if (eventId[i] == id) {
                cout << "Error: An event with this ID already exists." << endl;
                return;
            }
        }
        eventId[eventCount] = id;

        cin.ignore(); // clear newline
        string name, date, time, venue, desc;

        cout << "Enter Event Name: ";
        getline(cin, name);
        if (name.empty()) {
            cout << "Error: Name cannot be empty." << endl;
            return;
        }
        eventName[eventCount] = name;

        cout << "Enter Event Date (e.g., 2025-06-10): ";
        getline(cin, date);
        if (date.empty()) {
            cout << "Error: Date cannot be empty." << endl;
            return;
        }
        eventDate[eventCount] = date;

        cout << "Enter Event Time (e.g., 18:30): ";
        getline(cin, time);
        if (time.empty()) {
            cout << "Error: Time cannot be empty." << endl;
            return;
        }
        eventTime[eventCount] = time;

        cout << "Enter Event Venue: ";
        getline(cin, venue);
        if (venue.empty()) {
            cout << "Error: Venue cannot be empty." << endl;
            return;
        }
        eventVenue[eventCount] = venue;

        cout << "Enter Event Description: ";
        getline(cin, desc);
        if (desc.empty()) {
            cout << "Error: Description cannot be empty." << endl;
            return;
        }
        eventDescription[eventCount] = desc;

        eventCount++;
        saveEvents();
        cout << "Event added successfully!" << endl;
    }

    void displayEvents() {
        if (eventCount == 0) {
            cout << "No events to display." << endl;
            return;
        }

        cout << "\nEvent List:\n";
        for (int i = 0; i < eventCount; i++) {
            cout << "ID: " << eventId[i]
                << ", Name: " << eventName[i]
                    << ", Date: " << eventDate[i]
                        << ", Time: " << eventTime[i]
                            << ", Venue: " << eventVenue[i]
                                << ", Description: " << eventDescription[i]
                                    << endl;
        }
    }

    void searchEvent() {
        int id;
        cout << "Enter Event ID to search: ";
        cin >> id;

        bool found = false;
        for (int i = 0; i < eventCount; i++) {
            if (eventId[i] == id) {
                cout << "\nEvent Found:\n";
                cout << "ID: " << eventId[i] << endl;
                cout << "Name: " << eventName[i] << endl;
                cout << "Date: " << eventDate[i] << endl;
                cout << "Time: " << eventTime[i] << endl;
                cout << "Venue: " << eventVenue[i] << endl;
                cout << "Description: " << eventDescription[i] << endl;
                found = true;
                break;
            }
        }

        if (!found) {
            cout << "No event found with ID " << id << "." << endl;
        }
    }

    void saveEvents() {
        ofstream file("events.txt");
        if (file.is_open()) {
            for (int i = 0; i < eventCount; i++) {
                file << eventId[i] << "," << eventName[i] << "," << eventDate[i] << ","
                    << eventTime[i] << "," << eventVenue[i] << "," << eventDescription[i] << endl;
            }
            file.close();
        }
        else {
            cout << "Error: Could not save events to file." << endl;
        }
    }

    void loadEvents() {
        ifstream file("events.txt");
        if (file.is_open()) {
            string line;
            while (getline(file, line)) {
                int id;
                string name, date, time, venue, desc;

                size_t p1 = line.find(',');
                size_t p2 = line.find(',', p1 + 1);
                size_t p3 = line.find(',', p2 + 1);
                size_t p4 = line.find(',', p3 + 1);
                size_t p5 = line.find(',', p4 + 1);

                id = stoi(line.substr(0, p1));
                name = line.substr(p1 + 1, p2 - p1 - 1);
                date = line.substr(p2 + 1, p3 - p2 - 1);
                time = line.substr(p3 + 1, p4 - p3 - 1);
                venue = line.substr(p4 + 1, p5 - p4 - 1);
                desc = line.substr(p5 + 1);

                eventId[eventCount] = id;
                eventName[eventCount] = name;
                eventDate[eventCount] = date;
                eventTime[eventCount] = time;
                eventVenue[eventCount] = venue;
                eventDescription[eventCount] = desc;

                eventCount++;
            }
            file.close();
        }
        else {
            cout << "No previous event data found." << endl;
        }
    }

    void exportToCSV() {
        ofstream file("event_export.csv");
        if (file.is_open()) {
            file << "ID,Name,Date,Time,Venue,Description\n";
            for (int i = 0; i < eventCount; i++) {
                file << eventId[i] << "," << eventName[i] << "," << eventDate[i] << ","
                    << eventTime[i] << "," << eventVenue[i] << "," << eventDescription[i] << "\n";
            }
            file.close();
            cout << "Events exported to event_export.csv successfully!" << endl;
        }
        else {
            cout << "Error: Could not open file for CSV export." << endl;
        }
    }

    void exportToTXT() {
        ofstream file("event_export.txt");
        if (file.is_open()) {
            for (int i = 0; i < eventCount; i++) {
                file << "ID: " << eventId[i] << "\n"
                    << "Name: " << eventName[i] << "\n"
                    << "Date: " << eventDate[i] << "\n"
                    << "Time: " << eventTime[i] << "\n"
                    << "Venue: " << eventVenue[i] << "\n"
                    << "Description: " << eventDescription[i] << "\n"
                    << "------------------------\n";
            }
            file.close();
            cout << "Events exported to event_export.txt successfully!" << endl;
        }
        else {
            cout << "Error: Could not open file for TXT export." << endl;
        }
    }
};