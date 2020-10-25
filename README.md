# RetroPie Gamelist Cleaner

Apuohjelma RetroPien `gamelist.xml` -tiedoston siivoukseen ja oheistiedostojen poistoon EmulationStation -käyttöliittymän kautta poistetuista rom-tiedostoista.

EmulationStationin käyttöliitymän oma poistotoiminto ei valitettavasti poista pelin oheistiedostoja (kuvat, videot), eikä poista peliä `gamelist.xml` -tiedostosta. Näin ollen peli jää kummittelemaan pelilistaan vaikka sen rom-tiedosto onkin jo poistettu, ja pelin pelausyritys päätyy virheilmoitukseen. Gamelist Cleanerilla on mahdollista automaattisesti poistaa pelin oheistiedostot sekä pyyhkiä se `gamelist.xml`:stä.

![RetroPie Gamelist Cleaner](/docs/main.png)

## Käyttö

Käynnistettäessä ohjelma yrittää kirjautua RetroPiehen automaattisesti SSH:lla oletustunnuksilla (jos oletuksia on muutettu, voidaan muutetut kirjautumistiedot vaihtaa oletuksien tilalle ja painaa `Refresh`). Ohjelma hakee tiedot asennetuista emulaattoreista, ja halutun emulaattorin voi valita `Emulator` -pudotusvalikosta. Tämän jälkeen painetaan `Clean`-nappia, ja ohjelma hakee listan valitun emulaattorin kaikista rom-tiedostoista, ja vertaa löydettyjä tiedostoja `gamelist.xml` -tiedostoon merkittyihin peleihin. Mikäli `gamelist.xml` -tiedostossa on listattuna pelejä jotka on oikeasti poistettu, poistetaan pelin tiedot listalta. Myös oheistiedostot poistetaan, mutta ennen poistamista tiedostoista näytetään lista, jossa voidaan valita mitä haluaa poistaa vai poistetaanko kaikki.

Alkuperäinen `gamelist.xml` -tiedosto nimetään uudelleen päivämäärän mukaisesti, esim. `gamelist_old_2019-11-23-19-07-40.xml`, jolloin se on turvassa, jos uuden tiedoston luomisessa jokin menee pieleen.

## Lataus

En ota mitään vastuuta ohjelman mahdollisesti aiheuttamista vahingoista; kukin käyttää ohjelmaa omalla vastuullaan. Vaatimuksena Windows Vista tai uudempi, sekä .NET Framework 4.5. Huomioi, että ohjelmaan syötetty RetroPien salasana tallennetaan ohjelman kanssa samaan kansioon tallennettuun asetustiedostoon _salaamattomana_.

**[Lataa uusin versio](https://github.com/arikankainen/retropie-gamelist-cleaner-windows/releases)**
