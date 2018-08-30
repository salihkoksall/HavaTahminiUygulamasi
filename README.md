# HavaTahminiUygulamasi
Yapılan bu çalışmada örneğin hava durumu örneğinde meterojik verilerin tahmininde daha az verinin kullanılmasıyla daha doğru tahmin yaptığımızı anladık.Tahmin yaparken alınan veri boyutu arttıkça tahmin yapmanın daha güçleştiğini gördük.Ayrıca Excel üzerinde yapılan regresyon çalışmalarında regresyon işleminin birden fazla bağımlı  değişken ilede yapılabildiği gösterildi
# Form Ekranı Açıklama
<p>
Form ekranındaki zaman serileri verileri 2017 ocak 1  tarihinden 2018 mayıs 7 ye kadar toplamda 497 adet günlük veriyi tutmaktadır.Bu günlük hava koşulları verilerin her birinde bağımlı değişkenler olan MinT,MaxT,OrtT değerleri ayrıca bağımsız değişkenler olan Saturday(Cumartesi),Sunday(Pazar),Humidity(Nem oranı),YKY(yoğun kar yağışı),K(Kar),KY(Kar yağışlı),KKY(Karla Karışık Yağmur)…CB(Çok bulutlu),Pus(Puslu) ve yönleri belirten K (Kuzey),G(Güney)…KB(kuzey batı) bulunmaktatır.
 Data getir butonu MySQL very tabanından yanda gördüğümüz zaman serili veri setini getirmektedir.
Matrix X datagridi çoklu regresyon ve bir tahmin yapmadan önce bağımsız değişkenlerin seçildi kısımdır.
Matrix Y datagridi çoklu regresyon ve bir tahmin yapmadan önce bağımlı değişkenlerin seçildi kısımdır.
Bağımlı,bağımsız seçimleri yapıldıktan sonra matrise aktar ve hesapla demeden önce hesaplama yapmadan önce tahmin işleminin hangi zaman aralığında( haftalık,aylık veya yıllık) yapılması için seçenek koyulmuştur.
Seçimler yapıldıktan sonra tahmin yapılırken sonuçlar karşımıza sezonluk olarak çıkacaktır.Bu sezonlar model-1 den model-6 ya kadar ayrı ayrı gösterilmiştir.Sezonluk modellerşin anlamı aşağıdaki gibidir.
 Örneğin zaman aralığı haftalık seçilmişse;
Model 1: MySQLden çekilen veri tablosundan  sondan başlayarak 1 haftalık veriyi alır katsayı hesabı yapar ve tahmini gösterir.
Model 2: MySQLden çekilen veri tablosundan  sondan başlayarak 2 haftalık veriyi alır katsayı hesabı yapar ve tahmini gösterir.
Model 3: MySQLden çekilen veri tablosundan  sondan başlayarak 3 haftalık veriyi alır katsayı hesabı yapar ve tahmini gösterir.
Model 4: MySQLden çekilen veri tablosundan  sondan başlayarak 4 haftalık veriyi alır katsayı hesabı yapar ve tahmini gösterir.
Model 5: MySQLden çekilen veri tablosundan  sondan başlayarak 5 haftalık veriyi alır katsayı hesabı yapar ve tahmini gösterir.
Model 6: MySQLden çekilen veri tablosundan  sondan başlayarak 6 haftalık veriyi alır katsayı hesabı yapar ve tahmini gösterir.
Model ALL: Tüm veriyi alır katsayı hesabı yapar ve tahmini gösterir.
Bu veri setinden sonraki 7 günün maksimum sıcaklığı aşağıdaki tablodaki gibi olduğu gözlemlenmiştir.
    <p>
# Ekran Görüntüleri
<p>
<a href="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/8.png" target="_blank">
<img src="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/8.png" width="200" style="max-width:100%;"></a>
  <a href="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/7.png" target="_blank">
<img src="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/7.png" width="200" style="max-width:100%;"></a><a href="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/6.png" target="_blank">
<img src="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/6.png" width="200" style="max-width:100%;"></a><a href="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/5.png" target="_blank">
<img src="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/5.png" width="200" style="max-width:100%;"></a><a href="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/4.png" target="_blank">
<img src="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/4.png" width="200" style="max-width:100%;"></a><a href="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/3.png" target="_blank">
<img src="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/3.png" width="200" style="max-width:100%;"></a><a href="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/2.png" target="_blank">
<img src="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/2.png" width="200" style="max-width:100%;"></a><a href="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/1.png" target="_blank">
<img src="https://github.com/salihkoksall/HavaTahminiUygulamasi/blob/master/img2/1.png" width="200" style="max-width:100%;"></a>
<p>
 
  
