namespace Const
{
    public static class CO
    {
        //---------------------------------------------
        //// *** 環境設定 *** ////
        //---------------------------------------------
        // 固定フレームレート
        public const int TARGET_FRAME_RATE = 60;

        // ゲームバージョン
        public const string STRING_GAME_VERSION = "0.0.1";
        //---------------------------------------------
        //// *** ゲーム設定 *** ////
        //---------------------------------------------
        // 時間制限
        public const int TIME_LIMIT = 60;

        // タッチされてオブジェクトが移動し始めてから移動がおわるまでの時間(フレーム)
        // この間はタッチされてもUpdatePositionを行わない
        public const int MOVING_TIME = 7;

        //増加させるスコア量
        public const int ADD_SCORE = 10;

        // HSVのHの最大値
        public const int MAXHSVCOLOR = 360;

        // 時間制限
        public const float RAYCAST_MAX_DISTANCE = 20.0f;

        // RETRY(文字列)
        public const string STRING_RETRY = "RETRY";

        // GIVE UP(文字列)
        public const string STRING_GIVE_UP = "GIVE UP";
    }

}