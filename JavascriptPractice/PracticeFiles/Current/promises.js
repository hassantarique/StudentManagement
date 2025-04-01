import fs from "node:fs/promises";

fs.readFile('./data.json', 'utf8')
.then(data => {
    const dataObj = JSON.parse(data);
    console.log(dataObj);
    console.log("Complete");
})
.catch(err => {
    console.log("Could not complete load and parse");
    throw err;
});

const readFile = async (filename) => {
    return new Promise((resolve, reject) => {
      fsc.readFile('data.json', 'utf8', (err, data) => {
        if(err) {
          reject(err);
        }
        resolve(data);
      });
    });
}
