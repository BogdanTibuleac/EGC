<<<<<<< tema3
  # Intrebari laborator 3

  ``1. Care este ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)?``

  
   În OpenGL, ordinea în care sunt apelați vertex-urile determină direcția de desenare a poligonului. Dacă vertex-urile sunt apelate într-o ordine anti-orar, poligonul va fi desenat cu fața către utilizator; dacă sunt apelate într-o ordine orară, poligonul va fi desenat cu spatele către utilizator.

  ``2. Ce este anti-aliasing? Prezentați această tehnică pe scurt.``

  Anti-aliasing este o tehnică utilizată pentru a îmbunătăți aspectul liniilor și contururilor în grafica computerizată. Această tehnică ajută la reducerea aspectului denticioaselor (jagged) ale liniilor și marginilor, făcându-le să pară mai netede și mai naturale. Prin amestecarea culorilor din zona de tranziție dintre două obiecte sau între un obiect și fundal, anti-aliasingul creează iluzia unui contur mai precis.


``3. Care este efectul rulării comenzii GL.LineWidth(float)? Dar pentru GL.PointSize(float)? Funcționează în interiorul unei zone GL.Begin()?``

- GL.LineWidth(float) setează grosimea liniilor desenate în OpenGL. Această comandă modifică grosimea liniilor pentru toate liniile desenate în interiorul blocului GL.Begin() și GL.End().
- GL.PointSize(float) setează dimensiunea punctelor desenate în OpenGL. Această comandă modifică dimensiunea punctelor pentru toate punctele desenate în interiorul blocului GL.Begin() și GL.End().

``4. Directive in OpenGL``

- GL.LineLoop: Desenează un lanț de linii conectate, unde ultimul punct este conectat la primul. Aceasta creează o formă închisă.
- GL.LineStrip: Desenează un lanț de linii conectate, unde fiecare punct este conectat la punctul următor, creând o linie continuă.
- GL.TriangleFan: Desenează un ventil de triunghiuri, unde primul punct este centrul ventilului și fiecare pereche de puncte consecutive cu primul formează un triunghi.
- GL.TriangleStrip: Desenează o bandă de triunghiuri, unde primele trei puncte formează primul triunghi, iar fiecare punct adițional formează un triunghi nou cu ultimele două puncte și punctul anterior.

``5. De ce este importantă utilizarea de culori diferite (în gradient sau culori selectate per suprafață) în desenarea obiectelor 3D? ``

Utilizarea de culori diferite pe obiectele 3D ajută la evidențierea contururilor și a suprafețelor acestora. Culorile diferite permit o mai bună percepție a adâncimii și a formei obiectelor în spațiu. În plus, când se utilizează iluminare, culorile diferite pot evidenția reflectarea luminii și umbrelele pe obiecte, contribuind la realismul scenei 3D.

``7. Ce reprezintă un gradient de culoare?``
Un gradient de culoare este o tranziție graduală între două sau mai multe culori. În OpenGL, un gradient de culoare poate fi obținut utilizând shader-e pentru a interpola culorile între vertexurile obiectului. Aceasta se face prin specificarea culorilor pentru fiecare vertex și interpolarea acestora în interiorul triunghiului sau altei primitive, producând astfel un gradient de culoare. Shader-ele OpenGL pot fi programate pentru a efectua această interpolare și a crea efectul de gradient pe obiectele 3D.

``9. Ce efect are utilizarea unei culori diferite pentru fiecare vertex
atunci când desenați o linie sau un triunghi în modul strip?``


Atunci când desenați o linie sau un triunghi în modul strip și utilizați culori diferite pentru fiecare vertex, efectul este de colorare interpolată între aceste puncte. OpenGL va interpola culorile între vertex-uri, creând o tranziție lină de culoare pe întreaga formă, astfel încât aceasta să nu aibă o culoare uniformă, ci o variație în funcție de poziția pixelilor între vertex-uri. Acest lucru permite obținerea unor efecte vizuale mai complexe și mai estetice în desenarea obiectelor 3D.

  
  
=======
# Laborator EGC
Each section of the code corresponds to a specific homework assignment and its implementation.
>>>>>>> main
