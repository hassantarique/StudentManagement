import fs from "node:fs/promises";

try {
    const data = await fs.readFile('./data.json', 'utf8');
    console.log('File Read 1');
    await fs.readFile('./data.json', 'utf8');
    console.log('File Read 2');
    await fs.readFile('./data.json', 'utf8');
    console.log('File Read 3');
    const dataObj = JSON.parse(data);
    console.log(dataObj);
    console.log("Complete");
  } catch (err) {
    console.log("Could not load and parse file");
    throw err;
  }
  