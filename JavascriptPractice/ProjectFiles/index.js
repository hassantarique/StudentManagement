let employees = [
  {
    "id": 0,
    "email": "lamb_mcclain@globomantics.com",
    "firstName": "Lamb",
    "lastName": "Mcclain",
    "dateBirth": "1988-08-01",
    "startDate": "2001-05-22",
    "isActive": false
  },
  {
    "id": 1,
    "email": "bridges_deleon@globomantics.com",
    "firstName": "Bridges",
    "lastName": "Deleon",
    "dateBirth": "1993-05-16",
    "startDate": "2021-12-06",
    "isActive": true
  },
  {
    "id": 2,
    "email": "livingston_richardson@globomantics.com",
    "firstName": "Livingston",
    "lastName": "Richardson",
    "dateBirth": "1992-07-18",
    "startDate": "2001-12-26",
    "isActive": false
  },
  {
    "id": 3,
    "email": "boone_carney@globomantics.com",
    "firstName": "Boone",
    "lastName": "Carney",
    "dateBirth": "1990-08-02",
    "startDate": "2006-12-04",
    "isActive": false
  },
  {
    "id": 4,
    "email": "rosella_noel@globomantics.com",
    "firstName": "Rosella",
    "lastName": "Noel",
    "dateBirth": "1991-11-11",
    "startDate": "2019-03-24",
    "isActive": true
  },
  {
    "id": 5,
    "email": "katie_woodward@globomantics.com",
    "firstName": "Katie",
    "lastName": "Woodward",
    "dateBirth": "1990-05-05",
    "startDate": "2005-09-09",
    "isActive": false
  },
  {
    "id": 6,
    "email": "dionne_larsen@globomantics.com",
    "firstName": "Dionne",
    "lastName": "Larsen",
    "dateBirth": "1988-07-14",
    "startDate": "2005-01-13",
    "isActive": false
  },
  {
    "id": 7,
    "email": "santos_oneal@globomantics.com",
    "firstName": "Santos",
    "lastName": "Oneal",
    "dateBirth": "1994-01-13",
    "startDate": "2018-05-26",
    "isActive": true
  },
  {
    "id": 8,
    "email": "corine_house@globomantics.com",
    "firstName": "Corine",
    "lastName": "House",
    "dateBirth": "1994-08-28",
    "startDate": "2007-10-12",
    "isActive": true
  }
];

import createPrompt from 'prompt-sync';
let prompt = createPrompt();

const command = process.argv[2] ? process.argv[2].toLowerCase() : null;

if (!command) {
  console.error("Error: No command provided. Use 'list' or 'add'.");
  process.exit(1);
}

switch (command) {
  case 'list':
    console.log(`Employee List ----------------------------\n`);
    for (let emp of employees) {
      for (let property in emp) {
        console.log(`${property}: ${emp[property]}`);
      }
      console.log('');
      prompt('Press enter to continue...');
    }
    console.log(`Employee list completed`);
    break;

  case 'add':
    console.log(`Add Employee -----------------------------\n`);
    let employee = {};

    let firstName = prompt("First Name: ");
    if (!firstName) {
      console.error(`Invalid first name`);
      process.exit(1);
    }
    employee.firstName = firstName;

    let lastName = prompt("Last Name: ");
    if (!lastName) {
      console.error(`Invalid last name`);
      process.exit(1);
    }
    employee.lastName = lastName;

    let startDateYear = Number(prompt("Employee Start Year (1990-2023): "));
    if (!Number.isInteger(startDateYear) || startDateYear < 1990 || startDateYear > 2023) {
      console.error(`Enter a valid start date year within the range (1990-2023)`);
      process.exit(1);
    }

    let startDateMonth = Number(prompt("Employee Start Date Month (1-12): "));
    if (!Number.isInteger(startDateMonth) || startDateMonth < 1 || startDateMonth > 12) {
      console.error(`Enter a valid start date month (1-12)`);
      process.exit(1);
    }

    let startDateDay = Number(prompt("Employee Start Date Day (1-31): "));
    if (!Number.isInteger(startDateDay) || startDateDay < 1 || startDateDay > 31) {
      console.error(`Enter a valid start date day (1-31)`);
      process.exit(1);
    }

    employee.startDate = new Date(startDateYear, startDateMonth - 1, startDateDay);

    let isActive = prompt("Is employee active (yes or no): ").toLowerCase();
    if (isActive !== "yes" && isActive !== "no") {
      console.error(`Enter yes or no for employee active status`);
      process.exit(1);
    }
    employee.isActive = (isActive === "yes");

    console.log(`Employee Added:`, JSON.stringify(employee, null, 2));
    break;

  default:
    console.error("Unsupported command. Use 'list' or 'add'.");
    process.exit(1);
}
