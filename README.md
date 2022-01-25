# Point &amp; Click Office Game

## Performans İyileştirilmesi

Her framede çalışacak olan Update metodu içerisinde sürekli yenilenmesi veya kontrol edilmesi gerekmeyen kod parçaları yazılmaktan kaçınıldı.

Bir script içerisinde bir objenin componentine erişilmesi gerekilen durumlarda sürekli olarak GetComponent<T>() fonksiyonunu kullanmak yerine Start() veya 
Awake() fonksiyonu içerisinde bir değişkende tuturak istenildiğinde bu değişken ile ilgili componente erişim sağlanıldı.

Bir gameobject'e erişilmesi gereken durumlarda isim veya tage göre sahne içerisinde aramaktansa ilgili script içerisinde SerializeField olarak tanımlanan private 
değişkene Unity'de atama yapıldı.

Projeye dahil edilen ses dosyalarının yükleme tipi hafızaya alınırken sıkıştır, kalite değerleri ise 20 olarak Inpsector panelden seçildi. Bu proje bazında
düşük boyut ve az sayıda ses dosyası olduğundan kazanımlar çok gözükmese de Imported Size değeri 500 KB'dan 195 KB değerine kadar düşürüldü.

