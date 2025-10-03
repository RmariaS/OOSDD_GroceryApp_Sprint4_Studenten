# GroceryApp sprint4 Studentversie  

## UC10 Productaantal in boodschappenlijst
Aanpassingen zijn compleet.

## UC11 Meest verkochte producten
Vereist aanvulling:  
- Werk in GroceryListItemsService de methode GetBestSellingProducts uit.  
- In BestSellingProductsView de kop van de tabel aanvullen met de gewenste kopregel boven de tabel. Daarnaast de inhoud van de tabel uitwerken.

## UC13 Klanten tonen per product  
Deze UC toont de klanten die een bepaald product hebben gekocht:  
- Maak enum Role met als waarden None en Admin.  
- Geef de Client class een property Role metb als type de enum Role. De default waarde is None.  
- In Client Repo koppel je de rol Role.Admin aan user3 (= admin).
- In BoughtProductsService werk je de Get(productid) functie uit zodat alle Clients die product met productid hebben gekocht met client, boodschappenlijst en product in de lijst staan die wordt geretourneerd.  
- In BoughtProductsView moet de naam van de Client ewn de naam van de Boodschappenlijst worden getoond in de CollectionView.  
- In BoughtProductsViewModel de OnSelectedProductChanged uitwerken zodat bij een ander product de lijst correct wordt gevuld.  
- In GroceryListViewModel maak je de methode ShowBoughtProducts(). Als de Client de rol admin heeft dan navigeer je naar BoughtProductsView. Anders doe je niets.  
- In GroceryListView voeg je een ToolbarItem toe met als binding Client.Name en als Command ShowBoughtProducts.  


Voor de implementatie van UC11 en UC13 heb ik bewust en doordacht taalconcepten gekozen die voldoen aan de HBO-ICT coderichtlijnen, met  afwegingen tussen leesbaarheid, onderhoudbaarheid en performance.

1. Gebruik van LINQ in plaats van traditionele loops
In GroceryListItemsService.GetBestSellingProducts en BoughtProductsService.Get heb ik LINQ gebruikt voor groeperen, filteren en aggregeren (bijvoorbeeld GroupBy, Where, Sum). Dit verhoogt de leesbaarheid: de intentie van de code (“groepeer verkopen per product en tel het totaal”) is direct duidelijk, zonder boilerplate. Hoewel LINQ lichtjes meer overhead heeft dan een handmatige loop, is het verschil miniem bij de kleine datasets in deze app. De winst in onderhoudbaarheid en foutpreventie weegt zwwar op tegen deze minimale performancekost.

2. Enum Role voor toegangsbeheer
In plaats van strings of magische getallen (if (role == "admin")) heb ik een Role-enum ingevoerd. Dit verhoogt typeveiligheid, voorkomt spelfouten en maakt de code zelfdocumenterend. Dit sluit aan bij de richtlijn om domeinlogica expliciet en type safe te modelleren.

3. ItemDisplayBinding in .NET MAUI
Voor de Picker in BoughtProductsView heb ik ItemDisplayBinding="{Binding Name}" gebruikt in plaats van een custom renderer of code-behind. Dit is de  manier in MAUI om eigenschappen weer te geven, en zorgt voor een schone scheiding tussen UI-definitie (XAML) en logica (ViewModel). Dit verbetert de onderhoudbaarheid en voorkomt onnodige complexiteit.

4. Null-safe ontwerp met vroegtijdige returns
In services controleer ik input (productId <= 0) en null-waarden (product == null) direct aan het begin van de methode. Dit voorkomt diepe nesting, verlaagt cognitieve complexiteit en maakt de code robuuster, in lijn met de richtlijn om defensief en duidelijk te coderen.

Deze keuzes tonen een bewuste afweging waarbij leesbaarheid en onderhoudbaarheid centraal staan, zonder onnodige performance sacrifices, en volledig aansluiten bij de HBO-ICT coderichtlijnen.

  
