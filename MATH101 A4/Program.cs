
namespace MATH101_A4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            question1();
            question2();
            question3();
            question4();
            question5();
        }

        static void question1()
        {
            Random random = new Random();

            float X1 = random.Next(0,200);
            float Y1 = random.Next(0,200);

            float X2 = random.Next(0,200);
            float Y2 = random.Next(0,200);

            Vec vec1 = new Vec(X1, Y1);
            Vec vec2 = new Vec(X2, Y2);            

            //Vec vec3 = Vector2.vectorFrom2Points(vec1, vec2);
            Vec vec3 = mathLib.vectorFrom2Points(vec1, vec2);
            float magnitude = mathLib.Magnitude(vec3);

            Console.WriteLine($"Q1 Magnitude = {magnitude}\n");
        }

        static void question2()
        {
            // roomba
            Vec roombaVector = new(12.0f, 3.0f); // roomba is at 12,3
            Obj Roomba = new(roombaVector);

            //default
            //Vec keyID0 = new(0.0f, 1.0f);  // up
            //Vec keyID1 = new(1.0f, 0.0f);  // right
            //Vec keyID2 = new(0.0f, -1.0f); // down
            //Vec keyID3 = new(-1.0f, 0.0f); // left

            Vec keyID0 = new(0.0f, 0.0f);  // up
            Vec keyID1 = new(1.0f, 0.0f);  // right
            Vec keyID2 = new(0.0f, -1.0f); // down
            Vec keyID3 = new(0.0f, 0.0f); // left

            Vec movementDirection = mathLib.addVectorsTogether(keyID0, keyID1, keyID2, keyID3);
            Vec normalizedMovement = mathLib.Normalize(movementDirection);

            Console.WriteLine($"Q2 magnitude = {mathLib.Magnitude(normalizedMovement)}");
            Console.WriteLine($"initial position = {Roomba.positionFromOrigin.X},{Roomba.positionFromOrigin.Y}");

            Vec newPosition = mathLib.addVectorsTogether(normalizedMovement,roombaVector);
            Roomba.positionFromOrigin = newPosition;
            Console.WriteLine($"new Movement = {normalizedMovement.X},{normalizedMovement.Y}");
            Console.WriteLine($"new position = {Roomba.positionFromOrigin.X},{Roomba.positionFromOrigin.Y}\n");

        }

        static void question3()
        {
            
            int intensity = 2;
            Random random = new Random();

            float randomDegree = random.Next(0,360);
            randomDegree = -180;
            Console.WriteLine($"Question 3 \nDegree = {randomDegree}");
            Vec lightPulse = mathLib.genFromAngle(randomDegree, intensity);
            Console.WriteLine($"Lightpulse = {lightPulse.X},{lightPulse.Y}\n");
        }

        static void question4()
        {
            /*float X1 = random.Next(0,200);
            float Y1 = random.Next(0,200);
            float X2 = random.Next(0,200);
            float Y2 = random.Next(0,200);*/

            float X1 = 1.0f;
            float Y1 = 1.0f;

            float X2 = 1.5f;
            float Y2 = 1.5f;


            Vec vec1 = new(X1, Y1);
            Obj spaceShip = new(vec1, 4.0f);
            Vec vec2 = new(X2, Y2);
            Obj spaceDebris = new(vec2, 4.0f);

            float intersectionValue = mathLib.Collision(spaceDebris, spaceShip);
            Console.WriteLine(intersectionValue);
            if (intersectionValue >= 0.0f)
            {
                Console.WriteLine("Objs Collided");
            }
            else
            {
                Console.WriteLine("we have safely avoided the debris");
            }
        }

        static void question5()
        {
            // uses dot product
            //initialize value

            float X1 = 0.0f;
            float Y1 = 0.0f;

            float X2 = 30.0f;
            float Y2 = 30.0f;
            Vec vec1 = new(X1, Y1);
            Obj Sun = new(vec1, 1.0f);
            Vec vec2 = new(X2, Y2);
            Obj solarPanel = new(vec2, 0.5f);

            //^ ignore ^


            //sun to space ship x and y
            Vec sunToSpaceShip = mathLib.vectorFrom2Points(
                Sun.positionFromOrigin, solarPanel.positionFromOrigin);

            //solar panel normal (spnx, spny)
            Vec solarePanelNormal = mathLib.genFromAngle(225.0f);

            float percentage =mathLib.DotProduct(sunToSpaceShip, solarePanelNormal);
           Console.WriteLine($"{percentage}%");
        }
    }
}
