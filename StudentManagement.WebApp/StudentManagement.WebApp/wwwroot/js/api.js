let studentApiUrl = "https://motorsportapidev-cfgddcd9awb6gedr.uaenorth-01.azurewebsites.net/api/";

async function getAllStudents() {
    try {
        const response = await fetch(studentApiUrl + "Student/GetAllStudents");
        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Could not fetch data...", error);
        return [];
    }
}