import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class KeyListen implements KeyListener{
	
	/**
	 * Create a object of class EventKeyListener.
	 * @param game Object of class Game.
	 */
	public KeyListen(Game game){
		game.addKeyListener(this);
	}
	
	/**
	 * Handles pressed key.
	 * @param e object of class KeyEvent.
	 */
	public void keyPressed(KeyEvent e) {
		int keyPress = e.getKeyCode();
		
		if (keyPress == KeyEvent.VK_W || keyPress == KeyEvent.VK_UP) {
			if(Game.mySnake.getY() != 20){
				Game.mySnake.setX(0);
				Game.mySnake.setY(-20);
			}
		}
		if (keyPress == KeyEvent.VK_S || keyPress == KeyEvent.VK_DOWN) {
			if(Game.mySnake.getY() != -20){
				Game.mySnake.setX(0);
				Game.mySnake.setY(20);
			}
		}
		if (keyPress == KeyEvent.VK_D || keyPress == KeyEvent.VK_RIGHT) {
			if(Game.mySnake.getX() != -20){
			Game.mySnake.setX(20);
			Game.mySnake.setY(0);
			}
		}
		if (keyPress == KeyEvent.VK_A || keyPress == KeyEvent.VK_LEFT) {
			if(Game.mySnake.getX() != 20){
				Game.mySnake.setX(-20);
				Game.mySnake.setY(0);
			}
		}
		//Other controls
		if (keyPress == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
		
	}

}
