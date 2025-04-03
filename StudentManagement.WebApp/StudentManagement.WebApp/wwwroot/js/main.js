document.getElementById("getStudentsBtn").addEventListener("click", async function () {
    let students = await getAllStudents();
    bindTable(students);
});

function bindTable(students) {
    let tableBody = document.getElementById("studentsTableBody");
    tableBody.innerHTML = ""; // Clear previous rows

    students.forEach(student => {
        let row = tableBody.insertRow();

        row.insertCell(0).textContent = student.id;
        row.insertCell(1).textContent = student.name;
        row.insertCell(2).textContent = student.genderID === 1 ? "Male" : "Female";
        row.insertCell(3).textContent = new Date(student.dateOfBirth).toISOString().split('T')[0];
        row.insertCell(4).textContent = student.height;
        row.insertCell(5).textContent = student.weight;

        let actionsCell = row.insertCell(6);
        actionsCell.innerHTML = `
            <button class="btn btn-warning btn-sm">Edit</button>
            <button class="btn btn-danger btn-sm">Delete</button>
        `;
    });
}
