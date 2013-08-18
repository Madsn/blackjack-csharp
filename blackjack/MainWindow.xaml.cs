using System.Windows;

namespace blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player;
        Deck deck;
        Dealer dealer;
        int currentBet;

        public MainWindow()
        {
            InitializeComponent();
            startGame();
        }

        private void startGame()
        {
            player = new Player(5000);
            dealer = new Dealer();
            deck = new Deck();
            startRound();
            playerTurn();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            startGame();
        }

        private void startRound()
        {
            player.resetHand();
            dealer.resetHand();
            currentBet = 0;
            playerTurn();
            refreshGUI();
        }

        private void refreshGUI()
        {
            ErrorMsg.Content = "";
            CurrentBetLabel.Content = currentBet;
            DealerScoreLabel.Content = dealer.getScore();
            PlayerScoreLabel.Content = player.getScore();
            PlayerBalanceLabel.Content = player.getChipBalance();
            PlayerHandBox.Text = "";
            foreach (Card c in player.hand)
            {
                PlayerHandBox.Text += c.ToString() + "\n";
            }
            DealerHandBox.Text = "";
            foreach (Card c in dealer.hand)
            {
                DealerHandBox.Text += c.ToString() + "\n";
            }
        }

        private void BetButton_Click(object sender, RoutedEventArgs e)
        {
            // accept player bet
            try
            {
                currentBet = int.Parse(BetAmount.Text);
            }
            catch (System.FormatException error)
            {
                currentBet = 0;
            }
            if (currentBet <= 0)
            {
                ErrorMsg.Content = "Must enter numeric bet above 0";
                return;
            }
            if (currentBet > player.getChipBalance())
            {
                ErrorMsg.Content = "Insufficient funds";
                return;
            }
            player.getCard(deck.getNextCard());
            player.getCard(deck.getNextCard());
            dealer.getCard(deck.getNextCard());
            CurrentBetLabel.Content = currentBet;
            playerTurn();
            refreshGUI();
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            player.getCard(deck.getNextCard());
            refreshGUI();
            if (player.getScore() > 21)
            {
                ErrorMsg.Content = "Player bust. House wins";
                dealerWins();
            }
        }

        private void StayButton_Click(object sender, RoutedEventArgs e)
        {
            // Start dealer turn
            StayButton.IsEnabled = false;
            HitButton.IsEnabled = false;
            dealerTurn();
        }

        private void dealerTurn()
        {
            while (dealer.getScore() < 17)
            {
                dealer.getCard(deck.getNextCard());
            }
            refreshGUI();
            if (dealer.getScore() > 21)
            {
                ErrorMsg.Content = "Dealer busts, player wins";
                playerWins();
            }
            else if (dealer.getScore() > player.getScore())
            {
                ErrorMsg.Content = "House wins";
                dealerWins();
            }
            else 
            {
                ErrorMsg.Content = "Player wins";
                playerWins();
            }

        }

        private void playerWins()
        {
            player.obtainChips(currentBet);
            NextRoundButton.IsEnabled = true;
        }

        private void dealerWins()
        {
            HitButton.IsEnabled = false;
            StayButton.IsEnabled = false;
            player.loseChips(currentBet);
            if (player.getChipBalance() < 1)
            {
                refreshGUI();
                ErrorMsg.Content = "You're broke! Game over.";
                return;
            }
            NextRoundButton.IsEnabled = true;
        }

        private void playerTurn()
        {
            if (currentBet < 1)
            {
                BetButton.IsEnabled = true;
                HitButton.IsEnabled = false;
                StayButton.IsEnabled = false;
            }
            else
            {
                BetButton.IsEnabled = false;
                HitButton.IsEnabled = true;
                StayButton.IsEnabled = true;
            }
        }

        private void NextRoundButton_Click(object sender, RoutedEventArgs e)
        {
            if (deck.cards.Count < 15)
            {
                ErrorMsg.Content = "New deck of cards opened";
                deck = new Deck();
            }
            startRound();
        }

    }
}