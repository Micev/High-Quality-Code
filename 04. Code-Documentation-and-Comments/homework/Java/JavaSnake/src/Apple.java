import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random random;
	private Point startPoint;
	private Color snakeColor;
	
	public Apple(Snake s) {
		startPoint = createSnake(s);
		snakeColor = Color.RED;		
	}
	
	/**
	 * Create apple with random position.
	 * @param s Current snake.
	 * @return Return point element of type PointOfSnake
	 */
	private Point createSnake(Snake s) {
		random = new Random();
		int x = random.nextInt(30) * 20; 
		int y = random.nextInt(30) * 20;
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createSnake(s);				
			}
		}
		return new Point(x, y);
	}
	
	public void drawApple(Graphics g){
		startPoint.draw(g, snakeColor);
	}	
	
	public Point startingPoint(){
		return startPoint;
	}
}
