window.onload = function () {
  fetchGet('grafico/graficoInicial', 'text', function (data) {
    document.getElementById('imgFoto').src = 'data:image/png;base64,' + data
  })
}
