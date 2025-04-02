const myHeaders = new Headers();
myHeaders.append("apikey", "255113c83c4f798f72a490b404b8ab63");

const requestOptions = {
    method: 'GET',
    headers: myHeaders,
    redirect: 'follow'
};

try{
    const result = await fetch("https://api.apilayer.com/exchangerates_data/latest?base=USD", requestOptions);
    const resultObj = await result.json();
    console.log(JSON.stringify(resultObj, null, 2));
}
catch(err){
    console.error("Could not fetch data...");
    throw err;
}