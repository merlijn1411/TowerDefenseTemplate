# TowerDefenseTemplate
Dit is een template wat door jullie te gebruiken is voor het juist inleveren van alle producten voor de Towerdefense beroepsopdracht. **Verwijder uiteindelijk de template teksten!**

Begin met een korte omschrijving van je towerdefense game en hoe deze werkt. Plaats ook een paar screenshots.

![My Game](https://github.com/merlijn1411/TowerDefenseTemplate/assets/114576658/459be111-1fbb-4cd8-b112-7eb207d5aa00)
)

![also](https://github.com/merlijn1411/TowerDefenseTemplate/assets/114576658/6e96a6ef-05d3-4138-9dcc-03281d383631)
)


## Product 1: "DRY SRP Scripts op GitHub"

Plaats hier minimaal 1 link naar scripts die voldoen aan de eisen van **"Don't Repeat Yourself (DRY)"** en **"Single Responsibility Principle"**.
Omschrijf hier waarom jij denkt dat je in die scripts aan deze eisen voldoet.

in dit script is zijn enige functie om de healthbar uptedaten "Single Responsibility Principle". via de functie TakeDamage() update hij de healthbar als de functie word aangeroepen. 
[Link naar Script](https://github.com/merlijn1411/TowerDefenseTemplate/blob/develop/MyTowerDefenseGame/Assets/Scripts/Enemies/EnemyHealth.cs)


Bijvoorbeeld:

*"In dit script heb ik een array gebruikt voor al mijn vijanden die in de nieuwe wave worden gespawnd. Hierdoor heb ik mijzelf niet hoeven herhalen **(DRY)** in de code omdat ik met 1 regel alle enemies kan plaatsen via en for each loop.
[link naar script](/MyTowerDefenseGame/Assets/Scripts/JustAScript.cs)"*

## Product 2: "Projectmappen op GitHub"

Je commit de mappenstructuur van je unity project op github en verwijst vanuit je readme naar de root map van je project. Met een netjes en goed gestructureerde mappenstructuur en benamingen van files toon je aan dat je dit leerdoel beheerst. 

Dit is de [MIJN ROOT](https://github.com/merlijn1411/TowerDefenseTemplate/tree/develop/MyTowerDefenseGame) folder van mijn unity project.

Zorg dat deze verwijst naar je Develop branch.

## Product 3: Build op Github

Je maakt in Unity een stabiele “build” van je game waarbij bugs en logs eerst zijn verwijderd. Deze buildfiles upload je in je repository onder releases.  Bij eventuele afwijkingen moeten deze worden gedocumenteerd in de release. (Bijv controller nodig of spelen via netwerk etc..) 

[Release](https://github.com/merlijn1411/TowerDefenseTemplate/tree/master/Build)

## Product 4: Game met Sprites(animations) en Textures .

![ezgif com-video-to-gif](https://github.com/merlijn1411/TowerDefenseTemplate/assets/114576658/fc028dce-dfee-4fc9-a7fa-5b763f6f083a)


## Product 5: Issues met debug screenshots op GitHub 

![hier het probleem](https://github.com/merlijn1411/TowerDefenseTemplate/assets/114576658/2c0ae7dd-bc61-4ae6-8b22-dab1d094b201)

de bedoeling was dat de game zal beendigen als je al je levens kwijt bent ik checkde de methode eerst met een Debug.log zodat de game niet zou crashen. 

alleen toen al je levens op waren er niks verscheen in de console. het probleem was dat ik een aparte float had aangemaakt die niet gelinkd was met de PLayerstats. 

voor de duidelijkheid ik gebruik de playerstats script om aan te geven hoeveel levens je hebt en heveel geld je hebt. om dit probleem op te lossen moet ik het script aan roepen en de aangemaakt private float verwijderen. en het daarna veranderen van if(licves <= 0) naar if(PlayerStats.lives <= 0) zodat ik de goede variable kon aangeven.

![hier de oplossing](https://github.com/merlijn1411/TowerDefenseTemplate/assets/114576658/0b640ef2-f194-4727-9436-57860a019182)

![hier nog een screenshot van het PlayerStats script](https://github.com/merlijn1411/TowerDefenseTemplate/assets/114576658/945677fc-d64f-4eaa-a0b8-c0a689986786)



## Product 6: Game design met onderbouwing 

Je gebruikt een game design tool om je game design vast te leggen en te communiceren. Daarnaast onderbouw je de design keuzes ten aanzien van “playability” en “replayability” voor je game schriftelijk. 

Voorbeeld van een one page design:
![](https://external-preview.redd.it/48mnMpA0TbiihGo4HsJiWrJhK72xeTRwV2o70_AKilw.jpg?auto=webp&s=3a1ae18f0e4fba7a465643987cbe9cf409466e53)

Omschrijf per mechanic welke game design keuzes je hebt gemaakt en waarom je dit hebt gedaan.

*  **Je game bevat torens die kunnen mikken en schieten op een bewegend doel.** 

*Mijn torens hebben ook nog een f.o.v waardoor je pas gaan mikken als enemies in de buurt zijn. ook hebben mijn torens geen 360 graden view maar 90 graden waardoor het een extra uitdaging is voor de speler om de torens ook op de meest tactische manier te roteren.*

*  **Je game bevat vernietigbare vijanden die 1 of meerderen paden kunnen volgen.**  

*Mijn enemies bevatten 3 types: 
1 snelle die ook snel dood gaat. echter als er veel snelle enemies zijn is de kans steeds groter dat ze bij hun doel komen omdat de torens maar 1 enemy tegelijk kan targetten. Het forceert de speler dus om veel goedkope torens te plaatsen.
Ook is er een langzame gepantserde enemy. Deze kan eigenlijk alleen maar worden vernietigd door magische torens die zijn geupgrade. goedkope torens doen bijna geen schade. De speler moet dus een balans gaan zoeken tussen veel goedkope torens en upgraden van torens.
Tot slot is er een vijand die andere enemies healt dit zorgt ervoor dat de speler een extra nadeel heeft en de torens handmatig de deze healer moet laten targetten hierdoor wordt de speler gedwongen om actiever de game te spelen omdat anders geen enkele enemy meer dood gaat.*

*  **Je game bevat een “wave” systeem waarmee er onder bepaalde voorwaarden (tijd/vijanden op) nieuwe waves met vijanden het veld in komen.**

*Onderbouwing hier...*

*  **Een “health” systeem waarmee je levens kunt verliezen als vijanden hun doel bereiken en zodoende het spel kunt verliezen.** 

*Onderbouwing hier...*

*  **Een “resource” systeem waarmee je resources kunt verdienen waarmee je torens kunt kopen en .evt upgraden.**

*Onderbouwing hier...*

*  **Een “upgrade” systeem om je torens te verbeteren.**

*Onderbouwing hier...*

*  **Een “movement prediction” systeem waarmee je kan berekenen waar een toren heen moeten schieten om een bewegend object te kunnen raken. (Moeilijk)**

*Onderbouwing hier...*

## Product 7: Class Diagram voor volledige codebase 

[“My Class Diagram”](https://miro.com/welcomeonboard/TjEyMThpRmhndEFqTUFhNlBiVjlFblBMRVZvWkdrOFM1OVkxY2lvRXBoZEE3aGNJVU84V1VxNzNnSFp6UWNJZ3wzNDU4NzY0NTY2NjA4MDk3MzMxfDI=?share_link_id=522282518661) 


## Product 8: Prototype test video
Wat ik wou testen was day alle UI op zn plek zat, de waves beginnen en de enemy's daadwerkelijk spawnde. 

[![My Gameplay Clip](https://github.com/merlijn1411/TowerDefenseTemplate/assets/114576658/b2e3f5dc-7883-4a05-8bd9-e18b07a5c123)

## Product 9: SCRUM planning inschatting 

[Link naar mijn openbare trello](https://trello.com/b/DSJqXorz/bo-jaar-2-periode-1-td)

## Product 10: Gitflow conventions

Leg hier uit welke branches jij gaat gebruiken en wat voor namen je hier aan gaat meegeven. Hoe vaak ga je comitten en wat voor commit messages wil je geven?

Master: hier komt het hele product te staan met build dit moet is eigenlijk een soort van release branch. ik zou alleen willen commiten als ik het wil gaan release. in de commit komt te staan welke versie het is. 

Develop: hier in komt alles te staan en ga ik vooral de game uitesten voor dat ik het ga release en op de main/master branch zet. op deze branch probeer ik niet alte veel commiten alleen als het nodig is zoals de Build succesvol is ge build. de commit zou dan zijn build gelukt. 

Features : om nieuwe dingen toe te voegen gebruik ik de features branch. ik zou niet weten hoeveel commits ik ga geven maar wel wat de messages zijn. de messages zijn vooral over nieuwe ideeen in het spel uitegwerkt. 


Meer info over het gebruiken van gitflow [hier](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)

