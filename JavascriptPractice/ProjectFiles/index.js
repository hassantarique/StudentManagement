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

const logEmployee = (employee) => {
  Object.entries(employee).forEach(
    entry => {
      console.log(`${entry[0]}: ${entry[0]}}`); //key-value pair
    }
  );
};

function getInput(promptText, validator, transformer){
  let value = prompt(promptText);

  if(validator && !validator(value)){
    console.error(`--Invalid Input`);
    return getInput(promptText, validator, transformer);
  }

  if(transformer){
    return transformer(value);
  }

  return value;
}

// Validator functions ---------------------------------------------------

const isStringInputValid = (input) => {
  return input ? true : false;
}

const isBooleanInputValid = function (input) {
  return (input === "yes" || input === "no");
}

const isIntegerValid = (min, max) => {
  return(input) => {
    let numValue = Number(input);
    if(!Number.isInteger(numValue) || numValue < min || numValue > max) {
      return false;
    }
    return true;
  }
}

// Application commands --------------------------------------------------

function listEmployees() {
  console.log(`Employee List ----------------------------`);
  console.log('');

  employees.forEach(e => {
    logEmployee(e);
    prompt('Press enter to continue...');
  });
  console.log(`Employee list completed`);
}

function addEmployee() {
  console.log(`Add Employee -----------------------------`);
  console.log('');
  let employee = {};
  employee.firstName = getInput("First Name: ", isStringInputValid);
  employee.lastName = getInput("Last Name: ", isStringInputValid);
  let startDateYear = getInput("Employee Start Year (1990-2023): ", isIntegerValid(1990, 2023));
  let startDateMonth = getInput("Employee Start Date Month (1-12): ", isIntegerValid(1, 12));
  let startDateDay = getInput("Employee Start Date Day (1-31): ", isIntegerValid(1, 31));
  employee.startDate = new Date(startDateYear, startDateMonth - 1, startDateDay);
  employee.isActive = getInput("Is employee active (yes or no): ", isBooleanInputValid, i => (i === "yes"));
  
  // Output Employee JSON
  const json = JSON.stringify(employee, null, 2);
  console.log(`Employee: ${json}`);
}

// Search for employees by id
function searchById() {
 const id = getInput("Employee ID: ", null, Number);
 const result = employees.find(e => e.id === id);
 if (result) {
    console.log("");
    logEmployee(result);
  } else {
    console.log("No results...");
  }
}

// Search for employees by name
function searchByName() {
  const firstNameSearch = getInput("First Name: ").toLowerCase();
  const lastNameSearch = getInput("Last Name: ").toLowerCase();
  const results = employees.filter(e => {
    if (firstNameSearch && !e.firstName.toLowerCase().includes(firstNameSearch)) {
      return false;
    }
    if (lastNameSearch && !e.lastName.toLowerCase().includes(lastNameSearch)) {
      return false;
    }
    return true;
  });
  results.forEach((e, idx) => {
    console.log("");
    console.log(`Search Result ${idx + 1} -------------------------------------`);
    logEmployee(e);
  });
}

// Application execution -------------------------------------------------

// Get the command the user wants to exexcute
const command = process.argv[2].toLowerCase();

switch (command) {

  case 'list':
    listEmployees();
    break;

  case 'add':
    addEmployee();
    break;

  case 'search-by-id':
    searchById();
    break;

  case 'search-by-name':
    searchByName();
    break;

  default:
    console.log('Unsupported command. Exiting...');
    process.exit(1);

}



