  # Intrebari laborator 2

	Ce este un viewport?
Viewport defineste dimensiunile ferestrei unei suprafete tinta de redare pe care se proiecteaza un obiect, sau volum 3D.
Membrii unui viewport sunt: coordonatele X si Y; latimea si inaltimea; Min Z/ Max Z.
Acestia descriu pozitia si dimensiunile ferestrei pe suprafata tinta de redare. De obicei, aplicatiile sunt redate pe intreaga suprafata tinta; atunci cand se rendeaza pe o suprafata de 640x480, acesti membri trebuie sa fie 0, 0, 640 si respectiv 480. Proprietatile MinZ si MaxZ sunt deobicei setate la 0,0 si 1,0 dar pot fi setate la alte valori pentru a obtine efecte specifice.


	Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii OpenGL?
Frames per seconds (rata de cadre pe secunda) este frecventa cu care imaginile consecutive numite cadre apar pe un ecran. Acestea se mai pot numii si frame frequency si pot fi exprimate in hertz. 


	Când este rulată metoda OnUpdateFrame()?
Aceasta metoda este apelata atunci cand utilizatorul doreste sa actioneze intre timp asupra scenei motificand-o prin anumiti parametri(apasari de taste sau click al mouse-ului). 



	Ce este modul imediat de randare?
 Modul imediat de randare se referă la o tehnică de randare în OpenGL în care se utilizează funcții pentru a desena obiecte direct într-un singur apel, fără a utiliza un buffer de vertex sau un limbaj de shader. Această tehnică este mai puțin eficientă și mai puțin flexibilă decât modul de randare modern, bazat pe vertex shader și fragment shader.


	Care este ultima versiune de OpenGL care acceptă modul imediat?

Modulul imediat a fost eliminat din OpenGL începând cu versiunea OpenGL 3.0. Toate versiunile OpenGL ulterioare nu mai acceptă modul imediat, deoarece au trecut la un model de randare bazat pe shader-uri și buffer-e de vertex, care este mai puternic și mai flexibil.

	Când este rulată metoda OnRenderFrame()?
Aceasta metoda este rulata atunci cand dorim sa afisam in spatiul nostru ceea ce dorim sa proiectam (ex: corp geometric).


	De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
Metoda aceasta trebuie apelata cel putin odata pentru initierea afisarii si setarea viewport-ului grafic. Metoda este invocata la redimensionarea ferestrei. Aceasta va fi invocata dupa metoda OnLoad().


	Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?
Metoda CreatePerspectiveFieldOfView() este utilizată pentru a crea o matrice de proiecție perspectivă în OpenGL. Aceasta primește trei parametri:  
      - fieldOfView: Un unghi care reprezintă cât de largă este deschiderea de vizualizare în grade.  
      - aspectRatio: Raportul dintre lățime și înălțime al ferestrei sau a zonei de vizualizare.  
      - zNear și zFar: Distantele la care obiectele sunt afișate. Obiectele mai apropiate de zNear sau mai îndepărtate de zFar nu vor fi afișate.     Acești parametri determină domeniul de vizualizare și trebuie să fie pozitivi și nenuli.
