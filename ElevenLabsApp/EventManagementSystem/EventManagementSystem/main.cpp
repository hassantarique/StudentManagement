#include <iostream>
using namespace std;

#include "Event.cpp" // Includes the Event class

int main() {
    Event eventSystem;

    int choice;
    do {
        cout << "\n=== Hospital Event Management Menu ===" << endl;
        cout << "1. Add Event" << endl;
        cout << "2. Display All Events" << endl;
        cout << "3. Search Event by ID" << endl;
        cout << "4. Export Events to TXT" << endl;
        cout << "5. Export Events to CSV" << endl;
        cout << "0. Exit" << endl;
        cout << "Enter your choice: ";
        cin >> choice;

        switch (choice) {
        case 1:
            eventSystem.addEvent();
            break;
        case 2:
            eventSystem.displayEvents();
            break;
        case 3:
            eventSystem.searchEvent();
            break;
        case 4:
            eventSystem.exportToTXT();
            break;
        case 5:
            eventSystem.exportToCSV();
            break;
        case 0:
            cout << "Farewell, Exiting program." << endl;
            break;
        default:
            cout << "Invalid choice. Try again." << endl;
        }

    } while (choice != 0);

    return 0;
}
