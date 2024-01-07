
  # Intrebari laborator 10

``` Care este rolul comenzilor GL.Push() și GL. Pop()? De ce este
necesară utilizarea lor? ``` 


Comenzile GL.Push() și GL.Pop() sunt utilizate în OpenGL pentru a gestiona stiva de matrice de transformare a scenei.

GL.Push() este folosit pentru a salva starea matricei de transformare actuală pe stivă. Aceasta înseamnă că puteți aplica transformări noi fără a afecta sau modifica matricea curentă.
GL.Pop() este folosit pentru a elimina matricea de transformare curentă de pe stivă și pentru a reveni la starea salvată anterior cu GL.Push().

```Explicați efectul rulării metodelor GL.Rotate(), GL.Translate()
și GL.Scale(). Furnizați câte un exemplu comentat!```


Comenzile GL.Push() și GL.Pop() sunt utilizate în OpenGL pentru a gestiona stiva de matrice de transformare a scenei.

GL.Push() este folosit pentru a salva starea matricei de transformare actuală pe stivă. Aceasta înseamnă că puteți aplica transformări noi fără a afecta sau modifica matricea curentă.
GL.Pop() este folosit pentru a elimina matricea de transformare curentă de pe stivă și pentru a reveni la starea salvată anterior cu GL.Push().
Aceste comenzi sunt esențiale pentru că permit programatorilor să controleze și să gestioneze modificările aduse matricelor de transformare într-un mod organizat și reversibil.

Metodele GL.Rotate(), GL.Translate() și GL.Scale() sunt utilizate pentru a aplica transformări asupra obiectelor desenate în OpenGL.

GL.Rotate(angle, x, y, z) rotește obiectul cu un unghi dat în jurul axei definite de coordonatele (x, y, z).
GL.Translate(x, y, z) translează obiectul cu valorile x, y și z pe cele trei axe.
GL.Scale(x, y, z) scalează obiectul cu factorii x, y și z pe fiecare axă.

```Câte nivele de manipulări ierarhice (folosindu-se
GL.Push()/GL.Pop()) suportă o scenă OpenGL?

 ```
În ceea ce privește numărul de niveluri de manipulare ierarhică suportate de o scenă OpenGL, aceasta poate varia în funcție de implementare și de resursele hardware disponibile. În general, OpenGL permite o adâncime de stivă pentru manipulări de transformare, dar limita reală poate fi influențată de resursele sistemului și de configurația hardware. De obicei, însă, este posibil să folosiți o adâncime de stivă suficient de mare pentru majoritatea scenelor și aplicațiilor.
