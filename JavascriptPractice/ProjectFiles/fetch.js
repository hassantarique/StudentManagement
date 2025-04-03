// const myHeaders = new Headers();
// myHeaders.append("apikey", "");

let apiUrl = "https://motorsportapidev-cfgddcd9awb6gedr.uaenorth-01.azurewebsites.net/api/";

const requestOptions = {
    method: 'GET'
    // headers: myHeaders,
    // redirect: 'follow'
};

try{
    const result = await fetch(apiUrl + "Student/GetAllStudents", requestOptions);
    const resultObj = await result.json();
    console.log(JSON.stringify(resultObj, null, 2));
}
catch(err){
    console.error("Could not fetch data...");
    throw err;
}