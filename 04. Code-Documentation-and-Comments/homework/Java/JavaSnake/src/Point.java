import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Point {
	private int X, Y;
	private final int width = 20;
	private final int height = 20;
	
	/**
	 * Clones element of the snake.
	 * @param p Element of the snake.
	 */
	public Point(Point p){
		this(p.X, p.Y);
	}
	
	/**
	 * Creates new element of the snake on position X and Y.
	 * @param x X coordinate
	 * @param y Y coordinate
	 */
	public Point(int x, int y){
		this.X = x;
		this.Y = y;
	}	
		
	public int getX() {
		return X;
	}
	public void setX(int x) {
		this.X = x;
	}
	public int getY() {
		return Y;
	}
	public void setY(int y) {
		this.Y = y;
	}
	
	/**
	 * Draws snake's element.
	 * @param g Object of class Graphics.
	 */
	public void draw(Graphics g, Color cvqt) {
		g.setColor(Color.BLACK);
		g.fillRect(X, Y, width, height);
		g.setColor(cvqt);
		g.fillRect(X+1, Y+1, width-2, height-2);		
	}
	
	public String toString() {
		return "[x=" + X + ",y=" + Y + "]";
	}
	
	public boolean equals(Object obektjj) {
        if (obektjj instanceof Point) {
            Point to4ka = (Point)obektjj;
            return (X == to4ka.X) && (Y == to4ka.Y);
        }
        return false;
    }
}
