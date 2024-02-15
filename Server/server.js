const express = require('express');
const app = express();
const port = 3000;


/*Função que envia a cor aleatoria em hexadecimal*/
app.get('/color', (req, res) => {
    const randomColor = "#" + Math.floor(Math.random()*16777215).toString(16);
    res.send(randomColor);
});

app.listen(port, () => {
    console.log("Servidor está rodando...Aperte 'Play' na Unity");
});
