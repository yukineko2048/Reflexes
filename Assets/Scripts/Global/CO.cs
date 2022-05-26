namespace Const {
    public static class CO {
        //---------------------------------------------
        //// *** 環境設定 *** ////
        //---------------------------------------------
        // 固定フレームレート
        public const int TARGET_FRAME_RATE = 60;
        //---------------------------------------------
        //// *** ゲーム設定 *** ////
        //---------------------------------------------
        // 時間制限
        public const int TIME_LIMIT = 60;
        
        // タッチされてオブジェクトが移動し始めてから移動がおわるまでの時間(フレーム)
        // この間はタッチされてもUpdatePositionを行わない
        public const int MOVING_TIME = 7;

        // 時間制限
        public const float RAYCAST_MAX_DISTANCE = 20.0f;
    }

}