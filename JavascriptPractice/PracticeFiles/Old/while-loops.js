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

// Basic while loop
let i = 0;
while(employees[i]) {
  console.log(`Name: ${employees[i].firstName} ${employees[i].lastName}`);
  i++;
}

console.log('-----');

// Do while loop
i = 0;
do {
  console.log(`Name: ${employees[i].firstName} ${employees[i].lastName}`);
  i++;
} while(employees[i]);


